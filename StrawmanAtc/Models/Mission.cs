using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public struct Mission
    {
        public Mission(Spacetime objective, MissionAction action, DateTime issuedAt)
        {
            Objective = objective;
            Action = action;
            IssuedAt = issuedAt;
        }

        public DateTime IssuedAt { get; }
        public Spacetime Objective { get; }
        public MissionAction Action { get; }
    }
}
