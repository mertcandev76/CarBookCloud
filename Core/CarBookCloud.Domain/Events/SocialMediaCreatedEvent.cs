using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class SocialMediaCreatedEvent
    {
        public int SocialMediaID { get; }
        public string? Name { get; }
        public SocialMediaCreatedEvent(int socialMediaID, string? name) { SocialMediaID = socialMediaID; Name = name; }
    }
}
