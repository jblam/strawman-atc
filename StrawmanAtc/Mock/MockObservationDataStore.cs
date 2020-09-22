using System.Collections.Generic;
using System.Linq;
using StrawmanAtc.Models;

namespace StrawmanAtc.Mock
{
    class MockObservationDataStore : IObservationDataStore
    {
        public MockObservationDataStore()
            : this(new List<AtcUpdate>())
        {

        }
        private MockObservationDataStore(List<AtcUpdate> deprecatedUpdates)
        {
            updates = deprecatedUpdates;
        }

        MockObservationDataStore deprecatedData = null;
        readonly List<AtcUpdate> updates;
        public bool TryAdd(AtcUpdate update)
        {
            if (update.Metadata.Basis.HasValue)
            {
                if (updates.Count == 0 || updates[^1].Metadata.Id != update.Metadata.Basis)
                    return false;
                updates.Add(update);
                return true;
            }
            else
            {
                if (updates.Count > 0)
                {
                    // TODO: horrific, replace if this gets anywhere near production.
                    deprecatedData = new MockObservationDataStore(updates.ToList());
                    updates.Clear();
                }
                updates.Add(update);
                return true;
            }
        }
        public IEnumerable<AtcUpdate> Updates => updates.Select(u => u);
    }
}
