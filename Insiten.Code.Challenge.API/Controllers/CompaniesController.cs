using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Insiten.Code.Challenge.EF.Models;

namespace Insiten.Code.Challenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly InsitenCodeChallengeContext _context;

        public CompaniesController(InsitenCodeChallengeContext context)
        {
            _context = context;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<List<Companies>>> GetCompanies()
        {
            return await _context.Companies.Include(o => o.IdStatusNavigation).Where(o => o.Active).ToListAsync();
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Companies>> GetCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // PUT: api/Companies
        [HttpPut]
        public async Task<IActionResult> PutCompany(Companies company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            company.UpdatedDate = DateTime.Now;
            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(company.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(company);
        }

        // POST: api/Companies
        [HttpPost]
        public async Task<ActionResult<Companies>> PostCompany(Companies company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            company.Active = true;
            company.CreatedDate = DateTime.Now;
            company.UpdatedDate = DateTime.Now;
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanies", new { id = company.Id }, company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Companies>> DeleteCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            company.Active = false;
            company.UpdatedDate = DateTime.Now;
            _context.Entry(company).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
