using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public class SyncMetadata
    {
        public SyncId Id { get; set; }
        public SyncId? Basis { get; set; }
    }
}
