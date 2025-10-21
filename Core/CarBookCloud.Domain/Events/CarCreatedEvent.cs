using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class CarCreatedEvent
    {
        public int CarID { get; }
        public string? Model { get; }
        public CarCreatedEvent(int carID, string? model) { CarID = carID; Model = model; }

    }
}
  