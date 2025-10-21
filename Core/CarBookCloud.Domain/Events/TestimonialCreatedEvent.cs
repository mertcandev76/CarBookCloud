using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class TestimonialCreatedEvent
    {
        public int TestimonialID { get; }
        public string? Name { get; }
        public TestimonialCreatedEvent(int testimonialID, string? name) { TestimonialID = testimonialID; Name = name; }
    }
}
