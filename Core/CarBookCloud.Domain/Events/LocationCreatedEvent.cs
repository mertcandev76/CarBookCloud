using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class LocationCreatedEvent(int locationID, string? name)
    {
        public int LocationID { get; } = locationID; public string? Name { get; } = name;
    }
}
