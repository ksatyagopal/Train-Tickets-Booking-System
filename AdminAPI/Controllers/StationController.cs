using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminAPI.Models;
using AdminAPI.Codes;
using Microsoft.EntityFrameworkCore;

namespace AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        public readonly StationCodes codes = new();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Station>>> GetStation()
        {
            return Ok(await codes.List());
        }

        [HttpGet("{stationcode}")]
        public async Task<ActionResult<Station>> GetStationById(string stationcode)
        {
            var model = await codes.GetStationByCode(stationcode);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<Station>> PostStation(Station model)
        {
            return await codes.AddStation(model);
        }

        [HttpPut("{stationcode}")]
        public async Task<IActionResult> PutStation(string stationcode, Station model)
        {
            if (stationcode != model.StationCode)
            {
                return BadRequest();
            }
            try
            {
                var temp = await codes.List();
                if (temp.FindAll(e => e.StationCode == stationcode).Count == 0)
                {
                    return NotFound();
                }
                await codes.UpdateStation(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }


        [HttpDelete("{stationcode}")]
        public async Task<IActionResult> DeleteStation(string stationcode)
        {
            var model = await codes.GetStationByCode(stationcode);
            if (model == null)
            {
                return NotFound();
            }

            await codes.DeleteStation(model);
            return NoContent();
        }
    }
}
