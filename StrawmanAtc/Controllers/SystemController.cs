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

        [HttpPost]
        public ActionResult PostUpdate(AtcUpdate update)
        {
            var atc = dataStore[update.Metadata.Id.Owner];
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
