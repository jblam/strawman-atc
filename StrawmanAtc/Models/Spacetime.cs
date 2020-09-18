using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    /// <summary>
    /// Represents an observation of an event at a point in space and time
    /// </summary>
    public struct Spacetime
    {
        public Spacetime(Location location, DateTime time)
        {
            if (time.Kind != DateTimeKind.Utc)
                throw new InvalidOperationException("All datetimes must be UTC");
            Location = location;
            Time = time;
        }

        public Location Location { get; }
        public DateTime Time { get; }

        public override bool Equals(object obj)
        {
            return obj is Spacetime observation &&
                   Location.Equals(observation.Location) &&
                   Time == observation.Time;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Location, Time);
        }

        public static bool operator ==(Spacetime left, Spacetime right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Spacetime left, Spacetime right)
        {
            return !(left == right);
        }
    }
}
