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
            MockUpdates = deprecatedUpdates;
        }

        MockObservationDataStore deprecatedData = null;
        internal List<AtcUpdate> MockUpdates { get; }
        public bool TryAdd(AtcUpdate update)
        {
            if (update.Metadata.Basis != null)
            {
                if (MockUpdates.Count == 0 || MockUpdates[^1].Metadata.Id != update.Metadata.Basis)
                    return false;
                MockUpdates.Add(update);
                return true;
            }
            else
            {
                if (MockUpdates.Count > 0)
                {
                    // TODO: horrific, replace if this gets anywhere near production.
                    deprecatedData = new MockObservationDataStore(MockUpdates.ToList());
                    MockUpdates.Clear();
                }
                MockUpdates.Add(update);
                return true;
            }
        }
        public IEnumerable<AtcUpdate> Updates => MockUpdates.Select(u => u);
    }
}
