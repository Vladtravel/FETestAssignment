using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FETestAssignment.Data;
using FETestAssignment.Dtos;
using FETestAssignment.Models;
using Microsoft.AspNetCore.Http;

namespace FETestAssignment.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly FETestAssignmentContext _context;
        private readonly List<Company> _companies = new();

        public CompaniesController(FETestAssignmentContext context)
        {
            _context = context;
            
            for (var i = 1; i <= 9; ++i)
            {
                var company = new Company {Name = $"Company {i}", RegistryCode = $"12134{i}"};

                _companies.Add(company);
            }

        }

        /// <remarks>
        /// Returns some companies from public registry. Companies that have Id's are already existing in our system.
        /// </remarks>
        [HttpGet("my")]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompany()
        {
            var result = new List<CompanyDto>();
            
            foreach (var company in _companies)
            {
                var existingCompany =
                    await _context.Company.FirstOrDefaultAsync(c => c.RegistryCode == company.RegistryCode);

                if (existingCompany != null)
                {
                    company.Id = existingCompany.Id;
                }
                
                result.Add(new CompanyDto(company));
            }

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(Guid id)
        {
            var company = await _context.Company.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return new CompanyDto(company);
        }

        /// <remarks>
        /// Adds company with specified registry code to our system.
        /// </remarks>
        /// <param name="companyPostDto"></param>
        /// <returns>A newly created Company</returns>
        /// <response code="201">Returns the newly created Company</response>
        /// <response code="404">If the company is missing from companies in public registry</response>
        /// <response code="409">If the company is already in our system</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<CompanyDto>> PostCompany(CompanyPostDto companyPostDto)
        {
            var company = _companies.SingleOrDefault(c => c.RegistryCode == companyPostDto.RegistryCode);

            if (company == null)
            {
                return NotFound();
            }
            
            var existingCompany = await _context.Company.FirstOrDefaultAsync(c => c.RegistryCode == companyPostDto.RegistryCode);

            if (existingCompany != null)
            {
                return Conflict();
            }
            
            _context.Company.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new {id = company.Id}, new CompanyDto(company));
        }
    }
}