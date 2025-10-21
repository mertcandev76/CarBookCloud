using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.DTOs
{
    public class SocialMediaCreateDto
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }
    }

    public class SocialMediaUpdateDto: SocialMediaCreateDto
    {
        public int SocialMediaID { get; set; }
    }

    public class SocialMediaResultDto: SocialMediaCreateDto
    {
        public int SocialMediaID { get; set; }
    }
}
