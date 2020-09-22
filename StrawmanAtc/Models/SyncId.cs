using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public struct SyncId
    {
        public SyncId(string owner, DateTimeOffset timestamp)
        {
            if (string.IsNullOrWhiteSpace(owner))
            {
                throw new ArgumentException($"'{nameof(owner)}' cannot be null or whitespace", nameof(owner));
            }

            Owner = owner;
            Timestamp = timestamp;
        }

        public string Owner { get; }
        public DateTimeOffset Timestamp { get; }

        public override bool Equals(object obj)
        {
            return obj is SyncId id &&
                   Owner == id.Owner &&
                   Timestamp.Equals(id.Timestamp);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Owner, Timestamp);
        }

        public static bool operator ==(SyncId left, SyncId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SyncId left, SyncId right)
        {
            return !(left == right);
        }
    }
}
