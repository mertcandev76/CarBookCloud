using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class ServiceCreatedEvent
    {
        public int ServiceID { get; }
        public string? Title { get; }
        public ServiceCreatedEvent(int serviceID, string? title) { ServiceID = serviceID; Title = title; }
    }

}
