using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{

    public record FooterAddressCreatedEvent(int FooterAddressID)
        : DomainEventBase(DateTime.UtcNow);

    public record FooterAddressUpdatedEvent(int FooterAddressID)
        : DomainEventBase(DateTime.UtcNow);

    public record FooterAddressEmailChangedEvent(int FooterAddressID, string OldEmail, string NewEmail)
        : DomainEventBase(DateTime.UtcNow);
}
