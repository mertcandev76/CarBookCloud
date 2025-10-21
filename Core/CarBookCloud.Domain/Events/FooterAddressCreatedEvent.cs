using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class FooterAddressCreatedEvent(int footerAddressID)
    {
        public int FooterAddressID { get; } = footerAddressID;
    }
}
