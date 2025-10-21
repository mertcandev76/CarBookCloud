using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class CategoryCreatedEvent
    {
        public int CategoryID { get; }
        public string? Name { get; }
        public CategoryCreatedEvent(int categoryID, string? name) { CategoryID = categoryID; Name = name; }
    }
}
