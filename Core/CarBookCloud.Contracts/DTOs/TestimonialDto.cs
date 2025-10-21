using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.DTOs
{
    public class TestimonialCreateDto
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Comment { get; set; }
        public string? ImageUrl { get; set; }
    }

    public class TestimonialUpdateDto: TestimonialCreateDto
    {
        public int TestimonialID { get; set; }

    }

    public class TestimonialResultDto: TestimonialCreateDto
    {
        public int TestimonialID { get; set; }
    }
}
