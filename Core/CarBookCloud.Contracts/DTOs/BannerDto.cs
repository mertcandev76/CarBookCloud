using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.DTOs
{
    public class BannerCreateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? VideoDescription { get; set; }
        public string? VideoUrl { get; set; }
    }
    public class BannerUpdateDto:BannerCreateDto
    {
        public int BannerID { get; set; }
    }
    public class BannerResultDto: BannerCreateDto
    {
        public int BannerID { get; set; }
    }
}
