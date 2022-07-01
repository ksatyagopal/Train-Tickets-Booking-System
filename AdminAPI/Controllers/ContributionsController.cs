using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminAPI.Models;
using AdminAPI.Services;

namespace AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContributionsController : ControllerBase
    {
        private readonly IContributionService<Contribution> service;

        public ContributionsController(IContributionService<Contribution> _service)
        {
            service = _service;
        }

        // GET: api/Contributions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contribution>>> GetContributions()
        {
            return service.GetContributions();
        }

        // GET: api/Contributions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contribution>> GetContribution(int id)
        {
            var contribution = service.GetContribution(id);

            if (contribution == null)
            {
                return NotFound();
            }

            return contribution;
        }

        // PUT: api/Contributions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContribution(int id, Contribution contribution)
        {
            if (id != contribution.Cid)
            {
                return BadRequest();
            }

            try
            {
                service.EditContribution(contribution);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContributionExists(id))
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

        // POST: api/Contributions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contribution>> PostContribution(Contribution contribution)
        {
            service.AddContribution(contribution);
            return CreatedAtAction("GetContribution", new { id = contribution.Cid }, contribution);
        }

        // DELETE: api/Contributions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContribution(int id)
        {
            var contribution = service.GetContribution(id);
            if (contribution == null)
            {
                return NotFound();
            }

            service.DeleteContribution(id);

            return NoContent();
        }

        private bool ContributionExists(int id)
        {
            return service.ContributionExists(id);
        }
    }
}
