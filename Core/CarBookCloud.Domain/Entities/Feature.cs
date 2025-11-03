using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class Feature : IHasDomainEvents
    {
        public int FeatureID { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public ICollection<CarFeature> CarFeatures { get; private set; } = [];

        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private Feature() { } 

        private Feature(string name)
        {
            SetName(name);
        }

        public static Feature Create(string name)
        {
            var feature = new Feature(name);
            feature._domainEvents.Add(new FeatureCreatedEvent(feature.FeatureID, feature.Name));
            return feature;
        }

        public void Update(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Özellik adı boş olamaz.", nameof(name));

            if (Name != name)
            {
                Name = name;
                _domainEvents.Add(new FeatureUpdatedEvent(FeatureID, Name));
            }
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Özellik adı boş olamaz.", nameof(name));

            Name = name;
        }

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
