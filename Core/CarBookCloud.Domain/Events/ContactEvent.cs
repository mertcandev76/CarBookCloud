using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public record ContactCreatedEvent(int ContactID, string Name)
        : DomainEventBase(DateTime.UtcNow);

    public record ContactUpdatedEvent(int ContactID, string Name)
        : DomainEventBase(DateTime.UtcNow);

    public record ContactEmailChangedEvent(int ContactID, string OldEmail, string NewEmail)
        : DomainEventBase(DateTime.UtcNow);
}
