using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class BannerCreatedEvent(int bannerID, string? title)
    {
        public int BannerID { get; } = bannerID; public string? Title { get; } = title;
    }
}
