using StrawmanAtc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Mock
{
    public class MockAtcDataStore : IAtcDataStore
    {
        class MultiDictionary<TKey, TValue>
        {
            readonly Dictionary<TKey, List<TValue>> inner = new Dictionary<TKey, List<TValue>>();
            public IEnumerable<TValue> this[TKey key]
            {
                get
                {
                    if (inner.TryGetValue(key, out var values))
                        return values.Select(v => v);
                    return Enumerable.Empty<TValue>();
                }
            }
            public void Add(TKey key, TValue value)
            {
                if (!inner.TryGetValue(key, out var values))
                {
                    values = new List<TValue>();
                    inner.Add(key, values);
                }
                values.Add(value);
            }
            public IEnumerable<TKey> Keys => inner.Keys;
        }

        internal string MockName { get; set; }
        private readonly MultiDictionary<(string, Type), (Spacetime, object)> observations = new MultiDictionary<(string, Type), (Spacetime, object)>();
        private readonly MultiDictionary<string, Mission> missions = new MultiDictionary<string, Mission>();

        public string Name => MockName;
        public void AddObservation<TData>(string droneId, Observation<TData> observation) =>
            observations.Add((droneId, typeof(TData)), (observation.Spacetime, observation.Data));
        public void AddMission(string droneId, Mission mission) =>
            missions.Add(droneId, mission);
        public IQueryable<Observation<TData>> GetObservations<TData>(string droneId) =>
            observations[(droneId, typeof(TData))].Select(t => new Observation<TData>(t.Item1, (TData)t.Item2)).AsQueryable();
        public IQueryable<Mission> GetMissions(string droneId) => missions[droneId].AsQueryable();
        public IQueryable<string> GetDrones() => missions.Keys.AsQueryable();
    }
}
