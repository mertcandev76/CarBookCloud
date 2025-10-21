using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class AboutCreatedEvent(int aboutID, string? title)
    {
        public int AboutID { get; } = aboutID; public string? Title { get; } = title;
    }

}
