using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class TestimonialCreatedEvent(int testimonialID, string? name)
    {
        public int TestimonialID { get; } = testimonialID; public string? Name { get; } = name;
    }
}
