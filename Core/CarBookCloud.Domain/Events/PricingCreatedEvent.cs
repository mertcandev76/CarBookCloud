using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class PricingCreatedEvent(int pricingID, string? name)
    {
        public int PricingID { get; } = pricingID; public string? Name { get; } = name;
    }

}
