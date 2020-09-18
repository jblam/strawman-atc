using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    /// <summary>
    /// Represents a location in physical space through latitude and longitude
    /// </summary>
    public struct Location : IEquatable<Location>
    {
        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; }
        public double Longitude { get; }

        public override bool Equals(object obj)
        {
            return obj is Location location && Equals(location);
        }

        public bool Equals(Location other)
        {
            return Latitude == other.Latitude &&
                   Longitude == other.Longitude;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Latitude, Longitude);
        }

        public static bool operator ==(Location left, Location right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Location left, Location right)
        {
            return !(left == right);
        }
    }
}
