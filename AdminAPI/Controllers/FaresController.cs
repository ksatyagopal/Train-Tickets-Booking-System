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
    public class FaresController : ControllerBase
    {
        public readonly FareCodes fareCodes = new();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fare>>> GetFares()
        {
            return Ok(await fareCodes.List());
        }

        [HttpGet("{coach}")]
        public async Task<ActionResult<Admin>> GetFareByCoachType(string coach)
        {
            var fare = await fareCodes.GetMoneyByCoachType(coach);

            if (fare == null)
            {
                return NotFound();
            }

            return Ok(fare);
        }

        [HttpPost]
        public async Task<ActionResult<Fare>> PostFare(Fare fare)
        {
            return await fareCodes.AddFare(fare);
        }

        [HttpPut("{coach}")]
        public async Task<IActionResult> PutFare(string coach, Fare fare)
        {
            if (coach != fare.TypeOfCoach)
            {
                return BadRequest();
            }
            try
            {
                var temp = await fareCodes.List();
                if (temp.FindAll(e=>e.TypeOfCoach == coach).Count==0)
                {
                    return NotFound();
                }
                await fareCodes.UpdateFare(fare);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }


        [HttpDelete("{coach}")]
        public async Task<IActionResult> DeleteFare(string coach)
        {
            var fare = await fareCodes.GetMoneyByCoachType(coach);
            if (fare == null)
            {
                return NotFound();
            }

            await fareCodes.DeleteFare(fare);
            return NoContent();
        }

    }
}
