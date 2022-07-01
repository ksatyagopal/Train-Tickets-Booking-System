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
    public class StationDistanceController : ControllerBase
    {
        public readonly StationDistanceCodes codes = new();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationDistance>>> GetStationDistance()
        {
            return Ok(await codes.List());
        }

        
        [HttpPost]
        public async Task<ActionResult<StationDistance>> PostStationDistance(StationDistance model)
        {
            return await codes.AddStationDistance(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStationDistance(int id, StationDistance model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            try
            {
                var temp = await codes.List();
                if (temp.FindAll(e => e.Id == id).Count == 0)
                {
                    return NotFound();
                }
                await codes.UpdateStationDistance(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStationDistance(int id)
        {
            var model = (from i in await codes.List()
                         where i.Id == id
                         select i).FirstOrDefault();
            if (model == null)
            {
                return NotFound();
            }

            await codes.DeleteStationDistance(model);
            return NoContent();
        }
    }
}
