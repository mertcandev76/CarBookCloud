using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class CarPricingAddedEvent(int carPricingID, decimal amount)
    {
        public int CarPricingID { get; } = carPricingID; public decimal Amount { get; } = amount;
    }
}
