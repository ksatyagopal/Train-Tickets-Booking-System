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
    public class MasterListController : ControllerBase
    {
        public readonly MasterListCodes codes = new();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterList>>> GetMasterList()
        {
            return Ok(await codes.List());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MasterList>> GetMasterListById(int id)
        {
            var model = await codes.GetMasterListByID(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<MasterList>> PostMasterList(MasterList model)
        {
            return await codes.AddMasterList(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMasterList(int id, MasterList model)
        {
            if (id != model.Mid)
            {
                return BadRequest();
            }
            try
            {
                var temp = await codes.List();
                if (temp.FindAll(e => e.Mid == id).Count == 0)
                {
                    return NotFound();
                }
                await codes.UpdateMasterList(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMasterList(int id)
        {
            var model = await codes.GetMasterListByID(id);
            if (model == null)
            {
                return NotFound();
            }

            await codes.DeleteMasterList(model);
            return NoContent();
        }
    }
}
