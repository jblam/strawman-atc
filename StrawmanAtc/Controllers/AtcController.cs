using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StrawmanAtc.Models;

namespace StrawmanAtc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtcController : ControllerBase
    {
        private readonly ISystemDataStore system;

        public AtcController(ISystemDataStore system)
        {
            this.system = system;
        }

        ActionResult<T> NotFoundOr<T>(string atcName, Func<IAtcDataStore, T> ifFound)
        {
            var atc = system.Atcs.FirstOrDefault(a => a.Name.Equals(atcName, StringComparison.InvariantCultureIgnoreCase));
            if (atc == null)
                return NotFound();
            return Ok(ifFound(atc));
        }
        ActionResult NotFoundOr(string atcName, Func<IAtcDataStore, ActionResult> ifFound)
        {
            var atc = system.Atcs.FirstOrDefault(a => a.Name.Equals(atcName, StringComparison.InvariantCultureIgnoreCase));
            if (atc == null)
                return NotFound();
            return ifFound(atc);
        }

        [HttpGet("{atcName}")]
        public ActionResult<IEnumerable<string>> Get(string atcName = null) => NotFoundOr(atcName, s => s.GetDrones().AsEnumerable());

        [HttpGet("{atcName}/{droneName}/status")]
        public ActionResult<Observation<DroneState>> GetDroneStatus(string atcName = null, string droneName = null) =>
            NotFoundOr(atcName, s =>
            {
                var observation = s.GetObservations<DroneState>(droneName).OrderByDescending(o => o.Spacetime.Time).FirstOrDefault();
                if (observation.Spacetime == default)
                    return NotFound();
                return Ok(observation);
            });
        [HttpGet("{atcName}/{droneName}/mission")]
        public ActionResult<Observation<DroneState>> GetDroneMission(string atcName = null, string droneName = null) =>
            NotFoundOr(atcName, s =>
            {
                var mission = s.GetMissions(droneName).OrderByDescending(o => o.IssuedAt).FirstOrDefault();
                if (mission.IssuedAt == default)
                    return NotFound();
                return Ok(mission);
            });
    }
}
