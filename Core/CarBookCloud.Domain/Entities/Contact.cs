using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class Contact : IHasDomainEvents
    {
        public int ContactID { get; private set; }
        public string Name { get; private set; } = default!;
        public string? Email { get; private set; }
        public string? Subject { get; private set; }
        public string? Message { get; private set; }
        public DateTime SendDate { get; private set; }

        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private Contact() { } 

        private Contact(string name, string? email = null, string? subject = null, string? message = null)
        {
            SetName(name);
            Email = email;
            Subject = subject;
            Message = message;
            SendDate = DateTime.UtcNow;
        }

        //Factory Method
        public static Contact Create(string name, string? email = null, string? subject = null, string? message = null)
        {
            var contact = new Contact(name, email, subject, message);
            contact.AddDomainEvent(new ContactCreatedEvent(contact.ContactID, contact.Name));
            return contact;
        }

        //Güncelleme metodu
        public void Update(string name, string? email = null, string? subject = null, string? message = null)
        {
            bool isUpdated = false;

            if (!string.IsNullOrWhiteSpace(name) && Name != name)
            {
                SetName(name);
                isUpdated = true;
            }

            if (Email != email)
            {
                AddDomainEvent(new ContactEmailChangedEvent(ContactID, Email ?? string.Empty, email ?? string.Empty));
                Email = email;
                isUpdated = true;
            }

            if (Subject != subject)
            {
                Subject = subject;
                isUpdated = true;
            }

            if (Message != message)
            {
                Message = message;
                isUpdated = true;
            }

            if (isUpdated)
                AddDomainEvent(new ContactUpdatedEvent(ContactID, Name));
        }

        //Yardımcılar
        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ad boş olamaz.", nameof(name));

            Name = name;
        }

        private void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
