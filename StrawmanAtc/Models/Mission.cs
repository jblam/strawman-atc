using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public class Mission
    {
        public string Id { get; set; }
        public DateTime IssuedAt { get; set; }
        public Spacetime Objective { get; set; }
        public MissionAction Action { get; set; }
    }
}
