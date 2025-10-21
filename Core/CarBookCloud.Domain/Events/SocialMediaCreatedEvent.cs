using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class SocialMediaCreatedEvent(int socialMediaID, string? name)
    {
        public int SocialMediaID { get; } = socialMediaID; public string? Name { get; } = name;
    }
}
