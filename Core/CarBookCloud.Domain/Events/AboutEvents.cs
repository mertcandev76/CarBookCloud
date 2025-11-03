using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{

    public record AboutCreatedEvent(string Title) : DomainEventBase(DateTime.UtcNow);
    public record AboutTitleChangedEvent(int AboutID, string NewTitle) : DomainEventBase(DateTime.UtcNow);
}

