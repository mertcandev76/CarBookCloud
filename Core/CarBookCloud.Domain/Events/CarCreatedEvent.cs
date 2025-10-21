using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class CarCreatedEvent(int carID, string? model)
    {
        public int CarID { get; } = carID; public string? Model { get; } = model;
    }
}
  