using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class AboutCreatedEvent
    {
        public int AboutID { get; }
        public string? Title { get; }
        public AboutCreatedEvent(int aboutID, string? title) { AboutID = aboutID; Title = title; }
    }

}
