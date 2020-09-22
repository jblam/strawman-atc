using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Mock
{
    public class MockSystemDataStore : ISystemDataStore
    {
        internal Dictionary<string, IObservationDataStore> MockObservationStores { get; } = new Dictionary<string, IObservationDataStore>();
        public IObservationDataStore this[string name] => MockObservationStores[name];
        public IEnumerable<IObservationDataStore> ObservationStores => MockObservationStores.Values;
    }
}
