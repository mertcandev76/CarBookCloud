using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class FooterAddress : IHasDomainEvents
    {
        public int FooterAddressID { get; private set; }
        public string? Description { get; private set; }
        public string? Address { get; private set; }
        public string? Phone { get; private set; }
        public string? Email { get; private set; }

        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private FooterAddress() { }

        private FooterAddress(string? description, string? address, string? phone, string? email)
        {
            Description = description;
            Address = address;
            Phone = phone;
            Email = email;
        }

        //Factory Method
        public static FooterAddress Create(string? description, string? address, string? phone, string? email)
        {
            var footerAddress = new FooterAddress(description, address, phone, email);
            footerAddress.AddDomainEvent(new FooterAddressCreatedEvent(footerAddress.FooterAddressID));
            return footerAddress;
        }

        //Güncelleme metodu
        public void Update(string? description, string? address, string? phone, string? email)
        {
            bool isUpdated = false;

            if (Description != description) { Description = description; isUpdated = true; }
            if (Address != address) { Address = address; isUpdated = true; }
            if (Phone != phone) { Phone = phone; isUpdated = true; }

            if (Email != email)
            {
                AddDomainEvent(new FooterAddressEmailChangedEvent(FooterAddressID, Email ?? string.Empty, email ?? string.Empty));
                Email = email;
                isUpdated = true;
            }

            if (isUpdated)
                AddDomainEvent(new FooterAddressUpdatedEvent(FooterAddressID));
        }

        //Yardımcılar
        private void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
