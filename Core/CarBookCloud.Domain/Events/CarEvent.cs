using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public record CarCreatedEvent(string Model)
        : DomainEventBase(DateTime.UtcNow);

    public record CarPricingAddedEvent(int CarID, decimal Price)
        : DomainEventBase(DateTime.UtcNow);

    public record CarFeatureUpdatedEvent(int CarID, bool Available)
        : DomainEventBase(DateTime.UtcNow);

    public record CarDescriptionAddedEvent(int CarDescriptionID, int CarID)
        : DomainEventBase(DateTime.UtcNow);

    public record CarDescriptionUpdatedEvent(int CarDescriptionID, int CarID)
        : DomainEventBase(DateTime.UtcNow);
}
  