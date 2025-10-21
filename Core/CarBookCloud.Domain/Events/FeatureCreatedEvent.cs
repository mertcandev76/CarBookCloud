using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class FeatureCreatedEvent(int featureID, string name)
    {
        public int FeatureID { get; } = featureID; public string Name { get; } = name;
    }
}
