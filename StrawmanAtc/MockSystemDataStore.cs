using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc
{
    public class MockSystemDataStore
    {
        public IQueryable<IAtcDataStore> Atcs { get; }
    }
}
