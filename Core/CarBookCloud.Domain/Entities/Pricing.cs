using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class Pricing
    {
        public int PricingID { get; set; }
        public string? Name { get; set; }
        public ICollection<CarPricing> CarPricings { get; set; } = new List<CarPricing>();

        public List<object> DomainEvents { get; } = [];

        public Pricing() => DomainEvents.Add(new PricingCreatedEvent(PricingID, Name));
    }
}
