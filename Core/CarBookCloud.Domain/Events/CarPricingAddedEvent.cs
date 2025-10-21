using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class CarPricingAddedEvent
    {
        public int CarPricingID { get; }
        public decimal Amount { get; }
        public CarPricingAddedEvent(int carPricingID, decimal amount) { CarPricingID = carPricingID; Amount = amount; }
    }
}
