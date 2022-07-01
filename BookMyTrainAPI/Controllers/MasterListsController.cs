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
    public class MasterListsController : ControllerBase
    {
        private readonly BookMyTrainDBContext _context;

        public MasterListsController(BookMyTrainDBContext context)
        {
            _context = context;
        }

        // GET: api/MasterLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterList>>> GetMasterLists()
        {
            return await _context.MasterLists.ToListAsync();
        }

        [HttpGet("GetMasterListByUser/{id}")]
        public async Task<ActionResult<IEnumerable<MasterList>>> GetMasterListsByUser(int id)
        {
            return await (from i in _context.MasterLists where i.UserId == id select i).ToListAsync();
        }

        // GET: api/MasterLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MasterList>> GetMasterList(int id)
        {
            var masterList = await _context.MasterLists.FindAsync(id);

            if (masterList == null)
            {
                return NotFound();
            }

            return masterList;
        }

        // PUT: api/MasterLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMasterList(int id, MasterList masterList)
        {
            if (id != masterList.Mid)
            {
                return BadRequest();
            }

            _context.Entry(masterList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterListExists(id))
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

        // POST: api/MasterLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MasterList>> PostMasterList(MasterList masterList)
        {
            _context.MasterLists.Add(masterList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMasterList", new { id = masterList.Mid }, masterList);
        }

        // DELETE: api/MasterLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMasterList(int id)
        {
            var masterList = await _context.MasterLists.FindAsync(id);
            if (masterList == null)
            {
                return NotFound();
            }

            _context.MasterLists.Find(id).IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MasterListExists(int id)
        {
            return _context.MasterLists.Any(e => e.Mid == id);
        }
    }
}
