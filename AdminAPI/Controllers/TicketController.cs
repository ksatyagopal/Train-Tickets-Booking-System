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
    public class TicketController : ControllerBase
    {
        public readonly TicketCodes codes = new();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicket()
        {
            return Ok(await codes.List());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicketById(int id)
        {
            var model = await codes.GetTicketByID(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpGet("{pnr}")]
        public async Task<ActionResult<Ticket>> GetTicketsByPNR(long pnr)
        {
            var model = await codes.TicketListByPNR(pnr);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket model)
        {
            return await codes.AddTicket(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket model)
        {
            if (id != model.TicketId)
            {
                return BadRequest();
            }
            try
            {
                var temp = await codes.List();
                if (temp.FindAll(e => e.TicketId == id).Count == 0)
                {
                    return NotFound();
                }
                await codes.UpdateTicket(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var model = await codes.GetTicketByID(id);
            if (model == null)
            {
                return NotFound();
            }

            await codes.DeleteTicket(model);
            return NoContent();
        }
    }
}
