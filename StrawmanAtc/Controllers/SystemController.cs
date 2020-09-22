using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StrawmanAtc.Mock;
using StrawmanAtc.Models;

namespace StrawmanAtc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        private readonly ISystemDataStore dataStore;

        public SystemController(ISystemDataStore dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }

        [HttpGet("demo")]
        public ActionResult<AtcUpdate> GetDemo() => new AtcUpdate
        {
            AtcState = new AtcState
            {
                BatteryFraction = 0.7,
                Location = MockData.MelbourneIsh,
                UptimeSeconds = 120
            },
            Metadata = new SyncMetadata { Id = new SyncId("Alice", new DateTimeOffset(MockData.DevelopmentTime)) },
            Drones = new[] { new DroneUpdate { LatestState = new Observation<DroneState>(MockData.MelbourneDev, new DroneState(0.7, CompassDirection.East, 1.0)) } }
        };

        [HttpPost]
        public ActionResult PostUpdate([FromBody]AtcUpdate update)
        {
            var owner = update?.Metadata?.Id.Owner;
            if (owner == null)
                return BadRequest("Request did not specify the ATC");
            var atc = dataStore[owner];
            if (atc.TryAdd(update))
            {
                return Ok();
            }
            else
            {
                // TODO: re-request previous content?
                return BadRequest();
            }
        }

        [HttpGet("observations")]
        public ActionResult<IEnumerable<Observation<AtmosphericConditions>>> GetAtmosphericObservations()
        {
            return dataStore.ObservationStores.SelectMany(atc => atc.Updates.SelectMany(u => u.AtmosphericObservations)).ToList();
        }

        [HttpGet("drone-paths")]
        public IEnumerable<Observation<DroneState>> GetDronePaths()
        {
            return dataStore.ObservationStores.SelectMany(atc => atc.Updates.SelectMany(u => u.Drones.Select(d => d.LatestState)));
        }
    }
}
