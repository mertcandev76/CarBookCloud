using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class SocialMedia
    {
        public int SocialMediaID { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }
        public List<object> DomainEvents { get; } = [];
        public SocialMedia() => DomainEvents.Add(new SocialMediaCreatedEvent(SocialMediaID, Name));
    }
}
