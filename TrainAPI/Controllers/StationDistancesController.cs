using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainAPI.Models;

namespace TrainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationDistancesController : ControllerBase
    {
        private readonly TrainDBContext _context;

        public StationDistancesController(TrainDBContext context)
        {
            _context = context;
        }

        // GET: api/StationDistances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationDistance>>> GetStationDistances()
        {
            return await _context.StationDistances.ToListAsync();
        }

        // GET: api/StationDistances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StationDistance>> GetStationDistance(int id)
        {
            var stationDistance = await _context.StationDistances.FindAsync(id);

            if (stationDistance == null)
            {
                return NotFound();
            }

            return stationDistance;
        }

        // PUT: api/StationDistances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStationDistance(int id, StationDistance stationDistance)
        {
            if (id != stationDistance.Id)
            {
                return BadRequest();
            }

            _context.Entry(stationDistance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationDistanceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StationDistances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StationDistance>> PostStationDistance(StationDistance stationDistance)
        {
            _context.StationDistances.Add(stationDistance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStationDistance", new { id = stationDistance.Id }, stationDistance);
        }

        // DELETE: api/StationDistances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStationDistance(int id)
        {
            var stationDistance = await _context.StationDistances.FindAsync(id);
            if (stationDistance == null)
            {
                return NotFound();
            }

            _context.StationDistances.Remove(stationDistance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StationDistanceExists(int id)
        {
            return _context.StationDistances.Any(e => e.Id == id);
        }
    }
}
