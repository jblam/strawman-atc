using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Mock
{
    public class MockSystemDataStore : ISystemDataStore
    {
        internal Dictionary<string, IAtcDataStore> MockAtcs { get; } = new Dictionary<string, IAtcDataStore>();
        public void AddAtc(IAtcDataStore atc) => MockAtcs.Add(atc.Name, atc);
        public IQueryable<IAtcDataStore> Atcs => MockAtcs.Values.AsQueryable();
    }
}
