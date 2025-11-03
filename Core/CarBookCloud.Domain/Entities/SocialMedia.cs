using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class SocialMedia : IHasDomainEvents
    {
        public int SocialMediaID { get; private set; }
        public string Name { get; private set; } = default!;
        public string? Url { get; private set; }
        public string? Icon { get; private set; }

        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private SocialMedia() { } // EF Core için

        // Factory method
        public static SocialMedia Create(string name, string? url = null, string? icon = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ad boş olamaz.", nameof(name));

            var entity = new SocialMedia
            {
                Name = name,
                Url = url,
                Icon = icon
            };

            entity.AddDomainEvent(new SocialMediaCreatedEvent(entity.SocialMediaID, entity.Name));
            return entity;
        }

        // Update method
        public void Update(string? name = null, string? url = null, string? icon = null)
        {
            bool isUpdated = false;
            string oldName = Name;

            if (!string.IsNullOrWhiteSpace(name) && Name != name)
            {
                Name = name;
                AddDomainEvent(new SocialMediaNameChangedEvent(SocialMediaID, oldName, name));
                isUpdated = true;
            }

            if (Url != url)
            {
                Url = url;
                isUpdated = true;
            }

            if (Icon != icon)
            {
                Icon = icon;
                isUpdated = true;
            }

            if (isUpdated)
                AddDomainEvent(new SocialMediaUpdatedEvent(SocialMediaID, Name));
        }

        // Yardımcılar
        private void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
