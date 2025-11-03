using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarBookCloud.Contracts.Events
{
    public interface IDomainEventPublisher
    {
        Task PublishAsync<TEvent>(TEvent domainEvent) where TEvent : CarBookCloud.Domain.Events.IDomainEvent;
    }
}
