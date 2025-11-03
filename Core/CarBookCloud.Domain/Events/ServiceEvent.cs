using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{

    public record ServiceCreatedEvent(int ServiceID, string Title)
        : DomainEventBase(DateTime.UtcNow);

    public record ServiceUpdatedEvent(int ServiceID, string Title)
        : DomainEventBase(DateTime.UtcNow);

    public record ServiceTitleChangedEvent(int ServiceID, string OldTitle, string NewTitle)
        : DomainEventBase(DateTime.UtcNow);
}
