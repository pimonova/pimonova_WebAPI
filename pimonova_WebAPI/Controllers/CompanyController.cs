using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.DTOs.Company;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using static pimonova_WebAPI.Mappers.CompanyMappers;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/Companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Companies = await _context.Companies.ToListAsync();
            var CompanyDTO = Companies.Select(s => s.ToCompanyDTO());

            return Ok(Companies);
        }

        [HttpGet("{INN}")]
        public async Task<IActionResult> GetByINN([FromRoute] long INN)
        {
            var Company = await _context.Companies.FindAsync(INN);

            if (Company == null)
            {
                return NotFound();
            }

            return Ok(Company.ToCompanyDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyRequestDTO CompanyDTO)
        {
            var CompanyModel = CompanyDTO.ToCompanyFromCreateDTO();

            await _context.Companies.AddAsync(CompanyModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByINN), new {INN = CompanyModel.INN}, CompanyModel.ToCompanyDTO());
        }

        [HttpPut]
        [Route("{INN}")]
        public async Task<IActionResult> Update([FromRoute] long INN, [FromBody] UpdateCompanyRequestDTO UpdateDTO)
        {
            var CompanyModel = await _context.Companies.FirstOrDefaultAsync(x => x.INN == INN);

            if (CompanyModel == null)
            {
                return NotFound();
            }

            CompanyModel.FullName = UpdateDTO.FullName;
            CompanyModel.ShortName = UpdateDTO.ShortName;
            CompanyModel.RegAddress = UpdateDTO.RegAddress;
            CompanyModel.CurrAddress = UpdateDTO.CurrAddress;
            CompanyModel.PhoneNumber = UpdateDTO.PhoneNumber;
            //CompanyModel.INN = UpdateDTO.
            CompanyModel.KPP = UpdateDTO.KPP;
            CompanyModel.OGRN = UpdateDTO.OGRN;
            CompanyModel.Director = UpdateDTO.Director;
            CompanyModel.LineOfWork = UpdateDTO.LineOfWork;

            await _context.SaveChangesAsync();

            return Ok(CompanyModel.ToCompanyDTO());
        }

        [HttpDelete]
        [Route("{INN}")]
        public async Task<IActionResult> Delete([FromRoute] long INN)
        {
            var companyModel = await _context.Companies.FirstOrDefaultAsync(x => x.INN == INN);

            if(companyModel == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(companyModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
