using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class ContactCreatedEvent(int contactID, string name)
    {
        public int ContactID { get; } = contactID; public string Name { get; } = name;
    }
}
