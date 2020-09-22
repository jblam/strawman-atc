using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public class SyncMetadata
    {
        public SyncMetadata(SyncId id, SyncId? basis)
        {
            Id = id;
            Basis = basis;
        }

        public SyncId Id { get; }
        public SyncId? Basis { get; }
    }
}
