using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{

    public record TestimonialCreatedEvent(int TestimonialID, string Name)
        : DomainEventBase(DateTime.UtcNow);

    public record TestimonialUpdatedEvent(int TestimonialID, string Name)
        : DomainEventBase(DateTime.UtcNow);

    public record TestimonialNameChangedEvent(int TestimonialID, string OldName, string NewName)
        : DomainEventBase(DateTime.UtcNow);

}
