using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public record BrandCreatedEvent(int BrandID, string? Name)
        : DomainEventBase(DateTime.UtcNow);

    public record BrandNameChangedEvent(int BrandID, string? Name)
        : DomainEventBase(DateTime.UtcNow);
}
