using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class CarFeatureUpdatedEvent(int carFeatureID, bool available)
    {
        public int CarFeatureID { get; } = carFeatureID; public bool Available { get; } = available;
    }
}
