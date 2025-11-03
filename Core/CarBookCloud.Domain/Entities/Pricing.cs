using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class Pricing : IHasDomainEvents
    {
        public int PricingID { get; private set; }
        public string? Name { get; private set; }

        public ICollection<CarPricing> CarPricings { get; private set; } = [];

        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private Pricing() { } 

        private Pricing(string? name)
        {
            SetName(name);
        }


        public static Pricing Create(string? name)
        {
            var pricing = new Pricing(name);
            pricing._domainEvents.Add(new PricingCreatedEvent(pricing.PricingID, pricing.Name));
            return pricing;
        }


        public void Update(string? name)
        {
            if (Name != name)
            {
                SetName(name);
                _domainEvents.Add(new PricingUpdatedEvent(PricingID, Name));
            }
        }


        private void SetName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Fiyatlandırma adı boş olamaz.", nameof(name));

            Name = name;
        }

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
