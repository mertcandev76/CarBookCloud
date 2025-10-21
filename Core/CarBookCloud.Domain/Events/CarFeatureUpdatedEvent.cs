using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class CarFeatureUpdatedEvent
    {
        public int CarFeatureID { get; }
        public bool Available { get; }
        public CarFeatureUpdatedEvent(int carFeatureID, bool available) { CarFeatureID = carFeatureID; Available = available; }
    }
}
