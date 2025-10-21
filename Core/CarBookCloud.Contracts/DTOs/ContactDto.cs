using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.DTOs
{
    public class ContactCreateDto
    {
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? Subcect { get; set; }
        public string? Message { get; set; }
        public DateTime SendDate { get; set; }
    }

    public class ContactUpdateDto: ContactCreateDto
    {
        public int ContactID { get; set; }
    }

    public class ContactResultDto: ContactCreateDto
    {
        public int ContactID { get; set; }

    }
}
