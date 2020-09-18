using StrawmanAtc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Mock
{
    public static class MockData
    {
        public static readonly Location MelbourneIsh = new Location(-38, 145);
        public static readonly DateTime DevelopmentTime = new DateTime(2020, 9, 18, 4, 32, 0, DateTimeKind.Utc);
        public static readonly Spacetime MelbourneDev = new Spacetime(MelbourneIsh, DevelopmentTime);

        public static MockSystemDataStore CreateSystem()
        {
            var system = new MockSystemDataStore();
            system.AddAtc(MakeAtc("Alice"));
            system.AddAtc(MakeAtc("Bob"));
            return system;

            static IAtcDataStore MakeAtc(string name)
            {
                var output = new MockAtcDataStore
                {
                    MockName = name,
                };
                foreach (var id in Enumerable.Range(1, 5))
                {
                    var drone = $"{name}_{id}";
                    output.AddMission(drone, new Mission(MelbourneDev, MissionAction.Grounded, DevelopmentTime));
                    output.AddObservation(drone, new Observation<DroneState>(MelbourneDev, new DroneState(1, CompassDirection.North, 0)));
                }
                return output;
            }
        }
    }
}
