using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class FooterAddressCreatedEvent
    {
        public int FooterAddressID { get; }
        public FooterAddressCreatedEvent(int footerAddressID) { FooterAddressID = footerAddressID; }
    }
}
