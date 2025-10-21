using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class FeatureCreatedEvent
    {
        public int FeatureID { get; }
        public string Name { get; }
        public FeatureCreatedEvent(int featureID, string name) { FeatureID = featureID; Name = name; }
    }
}
