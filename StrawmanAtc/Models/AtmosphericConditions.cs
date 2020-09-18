using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public class AtmosphericConditions
    {
        public double WindSpeed { get; }
        public CompassDirection WindDirection { get; }
        public double Pressure { get; }
        public double Temperature { get; }
    }
}
