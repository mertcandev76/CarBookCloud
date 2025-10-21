using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string? Name { get; set; }
        public List<object> DomainEvents { get; } = [];
        public Category() => DomainEvents.Add(new CategoryCreatedEvent(CategoryID, Name));
    }
}
