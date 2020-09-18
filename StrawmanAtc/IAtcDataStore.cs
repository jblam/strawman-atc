using StrawmanAtc.Models;
using System.Linq;

namespace StrawmanAtc
{
    public interface IAtcDataStore
    {
        string Name { get; }

        void AddObservation<TData>(string droneId, Observation<TData> observation);
        void AddMission(string droneId, Mission mission);

        IQueryable<string> GetDrones();
        IQueryable<Mission> GetMissions(string droneId);
        IQueryable<Observation<TData>> GetObservations<TData>(string droneId);
    }
}