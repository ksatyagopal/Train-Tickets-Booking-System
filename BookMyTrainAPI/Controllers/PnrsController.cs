using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookMyTrainAPI.Models;

namespace BookMyTrainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PnrsController : ControllerBase
    {
        private readonly BookMyTrainDBContext _context;

        public PnrsController(BookMyTrainDBContext context)
        {
            _context = context;
        }

        // GET: api/Pnrs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pnr>>> GetPnrs()
        {
            return await _context.Pnrs.ToListAsync();
        }

        // GET: api/Pnrs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pnr>> GetPnr(long id)
        {
            var pnr = await _context.Pnrs.FindAsync(id);

            if (pnr == null)
            {
                return NotFound();
            }

            return pnr;
        }

        // PUT: api/Pnrs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPnr(long id, Pnr pnr)
        {
            if (id != pnr.Pnrnumber)
            {
                return BadRequest();
            }

            _context.Entry(pnr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PnrExists(id))
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

        // POST: api/Pnrs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pnr>> PostPnr(Pnr pnr)
        {
            _context.Pnrs.Add(pnr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPnr", new { id = pnr.Pnrnumber }, pnr);
        }

        // DELETE: api/Pnrs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePnr(long id)
        {
            var pnr = await _context.Pnrs.FindAsync(id);
            if (pnr == null)
            {
                return NotFound();
            }

            _context.Pnrs.Find(pnr.Pnrnumber).IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PnrExists(long id)
        {
            return _context.Pnrs.Any(e => e.Pnrnumber == id);
        }
    }
}
