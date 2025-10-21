using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class PricingCreatedEvent
    {
        public int PricingID { get; }
        public string? Name { get; }
        public PricingCreatedEvent(int pricingID, string? name) { PricingID = pricingID; Name = name; }
    }

}
