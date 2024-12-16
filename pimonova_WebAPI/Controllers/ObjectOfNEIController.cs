using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.DTOs.ObjectOfNEI;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using static pimonova_WebAPI.Mappers.ObjectOfNEIMappers;
using pimonova_WebAPI.DTOs.Company;
using pimonova_WebAPI.Helpers;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/ObjectsOfNEI")]
    [ApiController]
    public class ObjectOfNEIController : ControllerBase
    {
        private readonly IObjectOfNEIRepository _objectOfNEIRepo;
        private readonly ICompanyRepository _companyRepo;
        public ObjectOfNEIController(IObjectOfNEIRepository ObjectOfNEIRepo, ICompanyRepository CompanyRepo)
        {
            _objectOfNEIRepo = ObjectOfNEIRepo;
            _companyRepo = CompanyRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObjectForObjectOfNEI Query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ObjectsOfNEI = await _objectOfNEIRepo.GetAllAsync(Query);
            var ObjectsOfNEIDTO = ObjectsOfNEI.Select(s => s.ToObjectOfNEIDTO());

            return Ok(ObjectsOfNEI);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ObjectOfNEI = await _objectOfNEIRepo.GetByIdAsync(Id);

            if (ObjectOfNEI == null)
            {
                return NotFound("Object of negative environmental impact is not found");
            }

            return Ok(ObjectOfNEI.ToObjectOfNEIDTO());
        }

        [HttpPost("{CompanyId:int}")]
        public async Task<IActionResult> Create([FromRoute] int CompanyId, CreateObjectOfNEIRequestDTO ObjectOfNEIRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _companyRepo.CompanyExists(CompanyId))
            {
                return BadRequest("Company does not exist");
            }

            var ObjectOfNEIModel = ObjectOfNEIRequestDTO.ToObjectOfNEIFromCreateDTO(CompanyId);
            await _objectOfNEIRepo.CreateAsync(ObjectOfNEIModel);

            return CreatedAtAction(nameof(GetById), new {id = ObjectOfNEIModel.CompanyID}, ObjectOfNEIModel.ToObjectOfNEIDTO());
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateObjectOfNEIRequestDTO UpdateObjectOfNEIDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ObjectOfNEIModel = await _objectOfNEIRepo.UpdateAsync(Id, UpdateObjectOfNEIDTO.ToObjectOfNEIFromUpdateDTO());

            if (ObjectOfNEIModel == null)
            {
                return NotFound("Object of negative environmental impact is not found");
            }

            return Ok(ObjectOfNEIModel.ToObjectOfNEIDTO());
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ObjectOfNEIModel = await _objectOfNEIRepo.DeleteAsync(Id);

            if (ObjectOfNEIModel == null)
            {
                return NotFound("Object of negative environmental impact is not found");
            }

            return NoContent();
        }
    }
}
