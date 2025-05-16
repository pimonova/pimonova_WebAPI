using Microsoft.AspNetCore.Mvc;
using pimonova_WebAPI.DTOs.Sector;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Mappers;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/GasCleaners")]
    [ApiController]
    public class GasCleanerController : ControllerBase
    {
        private readonly IGasCleanerRepository _gasCleanerRepo;
        private readonly ISectorRepository _sectorRepo;
        public GasCleanerController(IGasCleanerRepository GasCleanerRepo, ISectorRepository SectorRepo)
        {
            _gasCleanerRepo = GasCleanerRepo;
            _sectorRepo = SectorRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var GasCleaners = await _gasCleanerRepo.GetAllAsync();

            var GasCleanersDTOs = GasCleaners.Select(s => s.ToGasCleanerDTO());

            return Ok(GasCleanersDTOs);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var GasCleaner = await _gasCleanerRepo.GetByIdAsync(Id);

            if (GasCleaner == null)
            {
                return NotFound("Gas cleaner is not found");
            }

            return Ok(GasCleaner.ToGasCleanerDTO());
        }

        //[HttpPost("{SectorId:int}")]
        //public async Task<IActionResult> Create([FromRoute] int SectorId, CreateGasCleanerRequestDTO GasCleanerRequestDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    if (!await _sectorRepo.SectorExists(SectorId))
        //    {
        //        return BadRequest("Sector does not exist");
        //    }

        //    var GasCleanerModel = GasCleanerRequestDTO.ToGasCleanerFromCreateDTO(SectorId);
        //    await _gasCleanerRepo.CreateAsync(GasCleanerModel);

        //    return CreatedAtAction(nameof(GetById), new { Id = GasCleanerModel.SectorID }, GasCleanerModel.ToGasCleanerDTO());
        //}

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var GasCleanerModel = await _gasCleanerRepo.DeleteAsync(Id);

            if (GasCleanerModel == null)
            {
                return NotFound("Gas cleaner is not found");
            }

            return NoContent();
        }
    }
}
