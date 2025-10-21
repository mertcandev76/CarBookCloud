using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class Feature
    {
        public int FeatureID { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<CarFeature> CarFeatures { get; set; } = [];
        public List<object> DomainEvents { get; } = [];
        public Feature() => DomainEvents.Add(new FeatureCreatedEvent(FeatureID, Name));
    }
}
