using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class CarDescriptionAddedEvent(int carDescriptionID, int carID)
    {
        public int CarDescriptionID { get; } = carDescriptionID; public int CarID { get; } = carID;
    }
}
