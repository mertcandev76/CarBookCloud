using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{

    public record PricingCreatedEvent(int PricingID, string? Name)
        : DomainEventBase(DateTime.UtcNow);

    public record PricingUpdatedEvent(int PricingID, string? Name)
        : DomainEventBase(DateTime.UtcNow);

}
