using StrawmanAtc.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc
{
    public interface ISystemDataStore
    {
        void AddAtc(IAtcDataStore atc);
        IQueryable<IAtcDataStore> Atcs { get; }

        IObservationDataStore this[string name] { get; }
        IEnumerable<IObservationDataStore> ObservationStores { get; }
    }
}
