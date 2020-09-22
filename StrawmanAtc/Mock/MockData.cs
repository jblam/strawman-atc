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
            return system;

        }
    }
}
