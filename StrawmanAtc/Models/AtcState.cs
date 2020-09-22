using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public class AtcState
    {
        public AtcState(double batteryFraction, Location location, TimeSpan uptime)
        {
            BatteryFraction = batteryFraction;
            Location = location;
            Uptime = uptime;
        }

        public double BatteryFraction { get; }
        public Location Location { get; }
        public TimeSpan Uptime { get; }
    }
}
