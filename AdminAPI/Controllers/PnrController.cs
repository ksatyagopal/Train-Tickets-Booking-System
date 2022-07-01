using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminAPI.Codes;
using AdminAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PnrController : ControllerBase
    {
        public readonly PnrCodes codes = new();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pnr>>> GetPnr()
        {
            return Ok(await codes.List());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pnr>> GetPnrById(long id)
        {
            var model = await codes.GetPnrByNumber(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<Pnr>> PostPnr(Pnr model)
        {
            return await codes.AddPnr(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPnr(long id, Pnr model)
        {
            if (id != model.Pnrnumber)
            {
                return BadRequest();
            }
            try
            {
                var temp = await codes.List();
                if (temp.FindAll(e => e.Pnrnumber == id).Count == 0)
                {
                    return NotFound();
                }
                await codes.UpdatePnr(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePnr(long id)
        {
            var model = await codes.GetPnrByNumber(id);
            if (model == null)
            {
                return NotFound();
            }

            await codes.DeletePnr(model);
            return NoContent();
        }
    }
}
