using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class BannerCreatedEvent
    {
        public int BannerID { get; }
        public string? Title { get; }
        public BannerCreatedEvent(int bannerID, string? title) { BannerID = bannerID; Title = title; }
    }
}
