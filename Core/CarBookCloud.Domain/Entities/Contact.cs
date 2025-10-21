using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? Subcect { get; set; }
        public string? Message { get; set; }
        public DateTime SendDate { get; set; }
        public List<object> DomainEvents { get; } = [];
        public Contact() => DomainEvents.Add(new ContactCreatedEvent(ContactID, Name));
    }
}
