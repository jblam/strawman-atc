using StrawmanAtc.Models;
using System.Collections.Generic;
using System.Linq;

namespace StrawmanAtc.Mock
{
    public interface IObservationDataStore
    {
        bool TryAdd(AtcUpdate update);
        IEnumerable<AtcUpdate> Updates { get; }
    }
}