﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public class DroneState
    {
        public double BatteryFraction { get; }
        public CompassDirection Heading { get; }
        public double Airspeed { get; }
    }
}
