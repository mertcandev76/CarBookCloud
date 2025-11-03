using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public record BannerCreatedEvent(int BannerID, string? Title)
        : DomainEventBase(DateTime.UtcNow);

    public record BannerTitleChangedEvent(int BannerID, string? Title)
        : DomainEventBase(DateTime.UtcNow);
}
