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
    public class ReachesController : ControllerBase
    {
        private readonly TrainDBContext _context;

        public ReachesController(TrainDBContext context)
        {
            _context = context;
        }

        // GET: api/Reaches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reach>>> GetReaches()
        {
            return await _context.Reaches.ToListAsync();
        }

        // GET: api/Reaches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reach>> GetReach(int id)
        {
            var reach = await _context.Reaches.FindAsync(id);

            if (reach == null)
            {
                return NotFound();
            }

            return reach;
        }

        // PUT: api/Reaches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReach(int id, Reach reach)
        {
            if (id != reach.Id)
            {
                return BadRequest();
            }

            _context.Entry(reach).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReachExists(id))
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

        // POST: api/Reaches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reach>> PostReach(Reach reach)
        {
            _context.Reaches.Add(reach);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReach", new { id = reach.Id }, reach);
        }

        // DELETE: api/Reaches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReach(int id)
        {
            var reach = await _context.Reaches.FindAsync(id);
            if (reach == null)
            {
                return NotFound();
            }

            _context.Reaches.Remove(reach);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReachExists(int id)
        {
            return _context.Reaches.Any(e => e.Id == id);
        }
    }
}
