using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class Location : IHasDomainEvents
    {
        public int LocationID { get; private set; }
        public string Name { get; private set; } = default!;

        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private Location() { } 

        // ✅ Factory Method
        public static Location Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ad boş olamaz.", nameof(name));

            var location = new Location
            {
                Name = name
            };

            location.AddDomainEvent(new LocationCreatedEvent(location.LocationID, location.Name));
            return location;
        }

        // ✅ Güncelleme metodu
        public void Update(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Ad boş olamaz.", nameof(newName));

            if (Name != newName)
            {
                string oldName = Name;
                Name = newName;

                AddDomainEvent(new LocationNameChangedEvent(LocationID, oldName, newName));
                AddDomainEvent(new LocationUpdatedEvent(LocationID, Name));
            }
        }

        // ✅ Yardımcılar
        private void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
