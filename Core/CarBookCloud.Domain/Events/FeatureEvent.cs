using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public record FeatureCreatedEvent(int FeatureID, string Name)
        : DomainEventBase(DateTime.UtcNow);

    public record FeatureUpdatedEvent(int FeatureID, string Name)
        : DomainEventBase(DateTime.UtcNow);
}
