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
    public class CompanyStatusController : ControllerBase
    {
        private readonly InsitenCodeChallengeContext _context;

        public CompanyStatusController(InsitenCodeChallengeContext context)
        {
            _context = context;
        }

        // GET: api/CompanyStatus
        [HttpGet]
        public async Task<ActionResult<List<CompanyStatus>>> GetCompanyStatus()
        {
            return await _context.CompanyStatus.Where(o => o.Active).ToListAsync();
        }

        // GET: api/CompanyStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyStatus>> GetCompanyStatus(int id)
        {
            var companyStatus = await _context.CompanyStatus.FindAsync(id);

            if (companyStatus == null)
            {
                return NotFound();
            }

            return companyStatus;
        }
 
    }
}
