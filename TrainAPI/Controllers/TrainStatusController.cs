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
    public class TrainStatusController : ControllerBase
    {
        private readonly TrainDBContext _context;

        public TrainStatusController(TrainDBContext context)
        {
            _context = context;
        }

        // GET: api/TrainStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainStatus>>> GetTrainStatuses()
        {
            return await _context.TrainStatuses.ToListAsync();
        }

        // GET: api/TrainStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TrainStatus>>> GetTrainStatus(int id)
        {
            var trainStatus = await (from each in _context.TrainStatuses
                               where each.TrainNumber == id
                               select each).ToListAsync();

            if (trainStatus == null)
            {
                return NotFound();
            }

            return trainStatus;
        }

        // PUT: api/TrainStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainStatus(int id, TrainStatus trainStatus)
        {
            if (id != trainStatus.Tsid)
            {
                return BadRequest();
            }

            _context.Entry(trainStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainStatusExists(id))
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

        // POST: api/TrainStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainStatus>> PostTrainStatus(TrainStatus trainStatus)
        {
            _context.TrainStatuses.Add(trainStatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrainStatusExists(trainStatus.Tsid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrainStatus", new { id = trainStatus.Tsid }, trainStatus);
        }

        // DELETE: api/TrainStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainStatus(int id)
        {
            var trainStatus = await _context.TrainStatuses.FindAsync(id);
            if (trainStatus == null)
            {
                return NotFound();
            }

            _context.TrainStatuses.Remove(trainStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainStatusExists(int id)
        {
            return _context.TrainStatuses.Any(e => e.Tsid == id);
        }
    }
}
