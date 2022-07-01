using AdminAPI.Codes;
using AdminAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReachController : ControllerBase
    {
        public readonly ReachCodes codes = new();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reach>>> GetReach()
        {
            return Ok(await codes.List());
        }

        [HttpPost]
        public async Task<ActionResult<Reach>> PostReach(Reach model)
        {
            return await codes.AddReach(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReach(int id, Reach model)
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
                await codes.UpdateReach(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReach(int id)
        {
            var list = await codes.List();
            var model = (from i in list where i.Id == id select i).FirstOrDefault();
            if (model == null)
            {
                return NotFound();
            }

            await codes.DeleteReach(model);
            return NoContent();
        }
    }
}
