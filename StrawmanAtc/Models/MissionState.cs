using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public class MissionState<TData>
    {
        public Mission Mission { get; set; }
        public MissionOutcome Outcome { get; set; }
        public IReadOnlyCollection<Observation<TData>> CapturedData { get; set; } = Array.Empty<Observation<TData>>();
    }
}
