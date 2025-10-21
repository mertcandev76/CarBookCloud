using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class CategoryCreatedEvent(int categoryID, string? name)
    {
        public int CategoryID { get; } = categoryID; public string? Name { get; } = name;
    }
}
