using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{

    // Tüm domain event’lerin kalıtım alacağı temel yapı
    public abstract record DomainEventBase(DateTime OccurredOn) : IDomainEvent
    {
        protected DomainEventBase() : this(DateTime.UtcNow) { }
    }
}
