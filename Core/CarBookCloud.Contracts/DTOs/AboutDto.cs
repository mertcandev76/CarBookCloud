using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.DTOs
{
    public class AboutCreateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
    public class AboutUpdateDto: AboutCreateDto
    {
        public int AboutID { get; set; }
    }

    public class AboutResultDto:AboutCreateDto
    {
        public int AboutID { get; set; }
    }
}
