using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{

    public record LocationCreatedEvent(int LocationID, string Name)
        : DomainEventBase(DateTime.UtcNow);

    public record LocationUpdatedEvent(int LocationID, string Name)
        : DomainEventBase(DateTime.UtcNow);

    public record LocationNameChangedEvent(int LocationID, string OldName, string NewName)
        : DomainEventBase(DateTime.UtcNow);
}
