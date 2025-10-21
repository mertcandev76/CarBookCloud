using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class ServiceCreatedEvent(int serviceID, string? title)
    {
        public int ServiceID { get; } = serviceID; public string? Title { get; } = title;
    }

}
