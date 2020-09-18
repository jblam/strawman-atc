using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public struct CompassDirection
    {
        private const int FullCircleDegrees = 360;
        public static readonly CompassDirection
            North = new CompassDirection(0),
            East = new CompassDirection(90),
            South = new CompassDirection(180),
            West = new CompassDirection(270);

        public double Degrees { get; }

        public CompassDirection(double degrees)
        {
            Degrees = ((degrees % FullCircleDegrees) + FullCircleDegrees) % FullCircleDegrees;
        }

        public override bool Equals(object obj)
        {
            return obj is CompassDirection direction &&
                   Degrees == direction.Degrees;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Degrees);
        }

        public static bool operator ==(CompassDirection left, CompassDirection right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CompassDirection left, CompassDirection right)
        {
            return !(left == right);
        }
    }
}
