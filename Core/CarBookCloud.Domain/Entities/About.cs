using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    // -----------------------------
    // Diğer Entity’ler (her biri kendi root olabilir)
    // -----------------------------
    public class About
    {
        public int AboutID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public List<object> DomainEvents { get; } = [];
        public About() => DomainEvents.Add(new AboutCreatedEvent(AboutID, Title));
    }
}
