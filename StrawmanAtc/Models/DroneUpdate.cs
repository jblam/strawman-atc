using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public class DroneUpdate
    {
        public Observation<DroneState> LatestState { get; set; }
        public Mission CurrentMission { get; set; }
        public IReadOnlyCollection<Observation<DeferredContent>> CapturedContent { get; set; } = Array.Empty<Observation<DeferredContent>>();
        public IReadOnlyCollection<string> AvailableContent { get; } = Array.Empty<string>();
    }
}
