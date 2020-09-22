using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public class AtcUpdate
    {
        public SyncMetadata Metadata { get; set; }
        public AtcState AtcState { get; set; }
        public IReadOnlyCollection<DroneUpdate> Drones { get; set; } = Array.Empty<DroneUpdate>();
        public IReadOnlyCollection<Observation<AtmosphericConditions>> AtmosphericObservations { get; set; } = Array.Empty<Observation<AtmosphericConditions>>();
        public IReadOnlyCollection<DeferredContent> DonwloadedContent { get; set; } = Array.Empty<DeferredContent>();
    }
}
