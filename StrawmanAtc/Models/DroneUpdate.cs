using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public class DroneUpdate
    {
        public Observation<DroneState> LatestState { get; }
        public Mission CurrentMission { get; }
        public IReadOnlyCollection<Observation<DeferredContent>> CapturedContent { get; }
        public IReadOnlyCollection<string> AvailableContent { get; }
    }
}
