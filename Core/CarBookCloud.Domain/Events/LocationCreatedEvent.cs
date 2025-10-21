using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class LocationCreatedEvent
    {
        public int LocationID { get; }
        public string? Name { get; }
        public LocationCreatedEvent(int locationID, string? name) { LocationID = locationID; Name = name; }
    }
}
