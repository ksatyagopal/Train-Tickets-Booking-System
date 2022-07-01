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
    public class UserController : ControllerBase
    {
        public readonly UserCodes codes = new();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return Ok(await codes.List());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var model = await codes.GetUserByID(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User model)
        {
            return await codes.AddUser(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User model)
        {
            if (id != model.UserId)
            {
                return BadRequest();
            }
            try
            {
                var temp = await codes.List();
                if (temp.FindAll(e => e.UserId == id).Count == 0)
                {
                    return NotFound();
                }
                await codes.UpdateUser(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var model = await codes.GetUserByID(id);
            if (model == null)
            {
                return NotFound();
            }

            await codes.DeleteUser(model);
            return NoContent();
        }
    }
}
