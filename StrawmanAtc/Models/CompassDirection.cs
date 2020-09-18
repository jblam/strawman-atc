using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public struct CompassDirection
    {
        public double Degrees { get; }

        public CompassDirection(double degrees)
        {
            // TODO: handle negative degrees
            Degrees = degrees % 360;
        }
    }
}
