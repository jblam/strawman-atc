using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public class AtcUpdate
    {
        public SyncMetadata Metadata { get; }
        public AtcState AtcState { get; }
        public IReadOnlyCollection<DroneUpdate> Drones { get; }
        public IReadOnlyCollection<Observation<AtmosphericConditions>> AtmosphericObservations { get; }
        public IReadOnlyCollection<DeferredContent> DonwloadedContent { get; }
    }
}
