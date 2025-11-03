using CarBookCloud.Contracts.Events;
using CarBookCloud.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Infrastructure.EventDispatching
{
    // DomainEvent → MediatR adaptörü
    public class MediatRDomainEventPublisher : IDomainEventPublisher
    {
        private readonly IMediator _mediator;

        public MediatRDomainEventPublisher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishAsync<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent
        {
            // DomainEvent'i MediatR INotification olarak yayınlanır.
            await _mediator.Publish(new DomainEventNotification<TEvent>(domainEvent));
        }
    }

    // Generic wrapper INotification
    public record DomainEventNotification<TEvent>(TEvent Event) : INotification where TEvent : IDomainEvent;
}
