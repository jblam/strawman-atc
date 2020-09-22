using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public enum MissionOutcome
    {
        NotStarted,
        Cancelled,
        InProgress,
        DataCaptured,
        Successful,
        Aborted,
        LostContact,
    }
}
