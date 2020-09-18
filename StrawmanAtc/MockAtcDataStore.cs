using StrawmanAtc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc
{
    public class MockAtcDataStore : IAtcDataStore
    {
        public string Name { get; }
        public IQueryable<Observation<TData>> GetObservations<TData>(string droneId) => throw new NotImplementedException();
        public IQueryable<Mission> GetMissions(string droneId) => throw new NotImplementedException();
        public IQueryable<string> GetDrones() => throw new NotImplementedException();
    }
}
