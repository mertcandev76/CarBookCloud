using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.DTOs
{
    public class FooterAddressCreateDto
    {
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }

    public class FooterAddressUpdateDto: FooterAddressCreateDto
    {
        public int FooterAddressID { get; set; }
    }

    public class FooterAddressResultDto: FooterAddressCreateDto
    {
        public int FooterAddressID { get; set; }
    }
}
