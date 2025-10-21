using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    // -----------------------------
    // Aggregate Root: Brand
    // Alt Entity: Car (Car bağımsız root)
    // -----------------------------
    public class Brand
    {
        public int BrandID { get; set; }
        public string? Name { get; set; }
        public ICollection<Car> Cars { get; set; } = [];

        public List<object> DomainEvents { get; } = [];

        public Brand()
        {
            DomainEvents.Add(new BrandCreatedEvent(BrandID, Name));
        }
    }

}
