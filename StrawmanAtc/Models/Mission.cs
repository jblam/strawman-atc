using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public class Mission
    {
        public Mission(string id, Spacetime objective, MissionAction action, DateTime issuedAt)
        {
            Objective = objective;
            Action = action;
            IssuedAt = issuedAt;
            Id = id;
        }
        public string Id { get; }
        public DateTime IssuedAt { get; }
        public Spacetime Objective { get; }
        public MissionAction Action { get; }
    }
}
