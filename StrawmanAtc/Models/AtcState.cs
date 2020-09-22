using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public class AtcState
    {
        public double BatteryFraction { get; set; }
        public Location Location { get; set; }
        [JsonIgnore]
        public TimeSpan Uptime => TimeSpan.FromSeconds(UptimeSeconds);
        public int UptimeSeconds { get; set; }
    }
}
