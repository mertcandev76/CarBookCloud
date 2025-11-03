using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class Service : IHasDomainEvents
    {
        public int ServiceID { get; private set; }
        public string Title { get; private set; } = default!;
        public string? Description { get; private set; }
        public string? IconUrl { get; private set; }

        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private Service() { } // EF Core için

        // ✅ Factory method
        public static Service Create(string title, string? description = null, string? iconUrl = null)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Başlık boş olamaz.", nameof(title));

            var service = new Service
            {
                Title = title,
                Description = description,
                IconUrl = iconUrl
            };

            service.AddDomainEvent(new ServiceCreatedEvent(service.ServiceID, service.Title));
            return service;
        }

        // ✅ Update method
        public void Update(string? title = null, string? description = null, string? iconUrl = null)
        {
            bool isUpdated = false;
            string oldTitle = Title;

            if (!string.IsNullOrWhiteSpace(title) && Title != title)
            {
                Title = title;
                AddDomainEvent(new ServiceTitleChangedEvent(ServiceID, oldTitle, title));
                isUpdated = true;
            }

            if (Description != description)
            {
                Description = description;
                isUpdated = true;
            }

            if (IconUrl != iconUrl)
            {
                IconUrl = iconUrl;
                isUpdated = true;
            }

            if (isUpdated)
                AddDomainEvent(new ServiceUpdatedEvent(ServiceID, Title));
        }

        // ✅ Yardımcılar
        private void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
