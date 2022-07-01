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
    public class TrainController : ControllerBase
    {
        public readonly TrainCodes codes = new();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Train>>> GetTrain()
        {
            return Ok(await codes.List());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Train>> GetTrainById(int id)
        {
            var model = await codes.GetTrainByNumber(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<Train>> PostTrain(Train model)
        {
            return await codes.AddTrain(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrain(int id, Train model)
        {
            if (id != model.TrainNumber)
            {
                return BadRequest();
            }
            try
            {
                var temp = await codes.List();
                if (temp.FindAll(e => e.TrainNumber == id).Count == 0)
                {
                    return NotFound();
                }
                await codes.UpdateTrain(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrain(int id)
        {
            var model = await codes.GetTrainByNumber(id);
            if (model == null)
            {
                return NotFound();
            }

            await codes.DeleteTrain(model);
            return NoContent();
        }
    }
}
