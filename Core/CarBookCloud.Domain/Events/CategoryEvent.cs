using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public record CategoryCreatedEvent(int CategoryID, string Name)
        : DomainEventBase(DateTime.UtcNow);

    public record CategoryNameChangedEvent(int CategoryID, string OldName, string NewName)
        : DomainEventBase(DateTime.UtcNow);
}
