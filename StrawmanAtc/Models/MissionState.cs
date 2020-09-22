using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public class MissionState<TData>
    {
        public Mission Mission { get; }
        public MissionOutcome Outcome { get; }
        public IReadOnlyCollection<Observation<TData>> CapturedData { get; }
    }
}
