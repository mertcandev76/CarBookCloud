using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class CarDescriptionAddedEvent
    {
        public int CarDescriptionID { get; }
        public int CarID { get; }
        public CarDescriptionAddedEvent(int carDescriptionID, int carID) { CarDescriptionID = carDescriptionID; CarID = carID; }
    }
}
