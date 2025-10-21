using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class ContactCreatedEvent
    {
        public int ContactID { get; }
        public string Name { get; }
        public ContactCreatedEvent(int contactID, string name) { ContactID = contactID; Name = name; }
    }
}
