using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Controllers;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Mappers;
using pimonova_WebAPI.DTOs.Sector;
using pimonova_WebAPI.DTOs.User;
using pimonova_WebAPI.Models;
using pimonova_WebAPI.DTOs.ObjectOfNEI;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/Sectors")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private readonly ISectorRepository _sectorRepo;
        private readonly IWorkshopRepository _workshopRepo;
        public SectorController(ISectorRepository SectorRepo, IWorkshopRepository WorkshopRepo)
        {
            _sectorRepo = SectorRepo;
            _workshopRepo = WorkshopRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Sectors = await _sectorRepo.GetAllAsync();

            var SectorsDTOs = Sectors.Select(s => s.ToSectorDTO());

            return Ok(SectorsDTOs);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Sector = await _sectorRepo.GetByIdAsync(Id);

            if (Sector == null)
            {
                return NotFound("Sector is not found");
            }

            return Ok(Sector.ToSectorDTO());
        }

        [HttpPost("{WorkshopId:int}")]
        public async Task<IActionResult> Create([FromRoute] int WorkshopId, CreateSectorRequestDTO SectorRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _workshopRepo.WorkshopExists(WorkshopId))
            {
                return BadRequest("Workshop does not exist");
            }

            var SectorModel = SectorRequestDTO.ToSectorFromCreateDTO(WorkshopId);
            await _sectorRepo.CreateAsync(SectorModel);

            return CreatedAtAction(nameof(GetById), new {Id = SectorModel.SectorID}, SectorModel.ToSectorDTO());
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateSectorRequestDTO UpdateSectorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var SectorModel = await _sectorRepo.UpdateAsync(Id, UpdateSectorDTO.ToSectorFromUpdateDTO());

            if (SectorModel == null)
            {
                return NotFound("Sector is not found");
            }

            return Ok(SectorModel.ToSectorDTO());
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var SectorModel = await _sectorRepo.DeleteAsync(Id);

            if (SectorModel == null)
            {
                return NotFound("Sector is not found");
            }

            return NoContent();
        }
    }
}
