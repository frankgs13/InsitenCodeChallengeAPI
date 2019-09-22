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
    public class CompanyKeyContactsController : ControllerBase
    {
        private readonly InsitenCodeChallengeContext _context;

        public CompanyKeyContactsController(InsitenCodeChallengeContext context)
        {
            _context = context;
        }

        // GET: api/CompanyKeyContacts/GetByCompanyId/5
        [HttpGet("GetByCompanyId/{CompanyId}")]
        public async Task<ActionResult<List<CompanyKeyContacts>>> GetByCompanyId(int CompanyId)
        {
            return await _context.CompanyKeyContacts.Where(o => o.CompanyId == CompanyId && o.Active).ToListAsync();
        }

        // GET: api/CompanyKeyContacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyKeyContacts>> GetCompanyKeyContact(int id)
        {
            var companyKeyContact = await _context.CompanyKeyContacts.FindAsync(id);

            if (companyKeyContact == null)
            {
                return NotFound();
            }

            return companyKeyContact;
        }

        // PUT: api/CompanyKeyContacts/5
        [HttpPut]
        public async Task<IActionResult> PutCompanyKeyContact(CompanyKeyContacts companyKeyContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            companyKeyContact.UpdatedDate = DateTime.Now;
            _context.Entry(companyKeyContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyKeyContactsExists(companyKeyContact.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(companyKeyContact);
        }

        // POST: api/CompanyKeyContacts
        [HttpPost]
        public async Task<ActionResult<CompanyKeyContacts>> PostCompanyKeyContact(CompanyKeyContacts companyKeyContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            companyKeyContact.Active = true;
            companyKeyContact.CreatedDate = DateTime.Now;
            companyKeyContact.UpdatedDate = DateTime.Now;
            _context.CompanyKeyContacts.Add(companyKeyContact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyKeyContact", new { id = companyKeyContact.Id }, companyKeyContact);
        }

        // DELETE: api/CompanyKeyContacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CompanyKeyContacts>> DeleteCompanyKeyContacts(int id)
        {
            var companyKeyContact = await _context.CompanyKeyContacts.FindAsync(id);
            if (companyKeyContact == null)
            {
                return NotFound();
            }

            companyKeyContact.Active = false;
            companyKeyContact.UpdatedDate = DateTime.Now;
            _context.Entry(companyKeyContact).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyKeyContactsExists(int id)
        {
            return _context.CompanyKeyContacts.Any(e => e.Id == id);
        }
    }
}
