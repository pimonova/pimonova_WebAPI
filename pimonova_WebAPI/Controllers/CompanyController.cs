using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll()
        {
            var Companies = _context.Companies.Select(s => s.ToCompanyDTO()).ToList();

            return Ok(Companies);
        }

        [HttpGet("{INN}")]
        public IActionResult GetByINN([FromRoute] long INN)
        {
            var Company = _context.Companies.Find(INN);

            if (Company == null)
            {
                return NotFound();
            }

            return Ok(Company.ToCompanyDTO());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCompanyRequestDTO CompanyDTO)
        {
            var CompanyModel = CompanyDTO.ToCompanyFromCreateDTO();

            _context.Companies.Add(CompanyModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetByINN), new {INN = CompanyModel.INN}, CompanyModel.ToCompanyDTO());
        }

        [HttpPut]
        [Route("{INN}")]
        public IActionResult Update([FromRoute] long INN, [FromBody] UpdateCompanyRequestDTO UpdateDTO)
        {
            var CompanyModel = _context.Companies.FirstOrDefault(x => x.INN == INN);

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

            _context.SaveChanges();

            return Ok(CompanyModel.ToCompanyDTO());
        }

        [HttpDelete]
        [Route("{INN}")]
        public IActionResult Delete([FromRoute] long INN)
        {
            var companyModel = _context.Companies.FirstOrDefault(x => x.INN == INN);

            if(companyModel == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(companyModel);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
