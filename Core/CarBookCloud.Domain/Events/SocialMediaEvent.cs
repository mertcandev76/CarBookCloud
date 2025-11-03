using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{

    public record SocialMediaCreatedEvent(int SocialMediaID, string Name)
        : DomainEventBase(DateTime.UtcNow);

    public record SocialMediaUpdatedEvent(int SocialMediaID, string Name)
        : DomainEventBase(DateTime.UtcNow);

    public record SocialMediaNameChangedEvent(int SocialMediaID, string OldName, string NewName)
        : DomainEventBase(DateTime.UtcNow);
}
