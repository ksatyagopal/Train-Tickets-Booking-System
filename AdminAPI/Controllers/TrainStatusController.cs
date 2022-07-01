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
    public class TrainStatusController : ControllerBase
    {
        public readonly TrainStatusCodes codes = new();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainStatus>>> GetTrainStatus()
        {
            return Ok(await codes.List());
        }

        [HttpGet("{trainnumber}")]
        public async Task<ActionResult<TrainStatus>> GetTrainStatusById(int trainnumber)
        {
            var model = await codes.GetTrainStatusByTrain(trainnumber);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<TrainStatus>> PostTrainStatus(TrainStatus model)
        {
            return await codes.AddTrainStatus(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainStatus(int id, TrainStatus model)
        {
            if (id != model.tsId)
            {
                return BadRequest();
            }
            try
            {
                var temp = await codes.List();
                if (temp.FindAll(e => e.tsId == id).Count == 0)
                {
                    return NotFound();
                }
                await codes.UpdateTrainStatus(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainStatus(int id)
        {
            var model = (from i in await codes.List()
                         where i.tsId == id
                         select i).FirstOrDefault();
            if (model == null)
            {
                return NotFound();
            }

            await codes.DeleteTrainStatus(model);
            return NoContent();
        }
    }
}
