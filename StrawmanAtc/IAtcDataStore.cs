using StrawmanAtc.Models;
using System.Linq;

namespace StrawmanAtc
{
    public interface IAtcDataStore
    {
        string Name { get; }

        IQueryable<string> GetDrones();
        IQueryable<Mission> GetMissions(string droneId);
        IQueryable<Observation<TData>> GetObservations<TData>(string droneId);
    }
}