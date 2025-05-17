using Microsoft.AspNetCore.Mvc;
using pimonova_WebAPI.DTOs.GasCleaner;
using pimonova_WebAPI.DTOs.MobileIZAV;
using pimonova_WebAPI.DTOs.Sector;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Mappers;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/GasCleaners")]
    [ApiController]
    public class GasCleanerController : ControllerBase
    {
        private readonly IGasCleanerRepository _gasCleanerRepo;
        private readonly ISectorRepository _sectorRepo;
        private readonly IStationaryIZAVRepository _stationaryIZAVRepo;
        public GasCleanerController(IGasCleanerRepository GasCleanerRepo, IStationaryIZAVRepository StationaryIZAVRepo, ISectorRepository SectorRepo)
        {
            _gasCleanerRepo = GasCleanerRepo;
            _sectorRepo = SectorRepo;
            _stationaryIZAVRepo = StationaryIZAVRepo;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGasCleanerRequestDTO GasCleanerRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (GasCleanerRequestDTO.StationaryIZAVToOut == null || !await _stationaryIZAVRepo.StationaryIZAVExists(GasCleanerRequestDTO.StationaryIZAVToOut.Value))
            {
                return NotFound("Stationary IZAV is not found");
            }

            if (GasCleanerRequestDTO.SectorID == null || !await _sectorRepo.SectorExists(GasCleanerRequestDTO.SectorID.Value))
            {
                return BadRequest("Sector is not found");
            }

            var GasCleanerModel = GasCleanerRequestDTO.ToGasCleanerFromCreateDTO();

            await _gasCleanerRepo.CreateAsync(GasCleanerModel);

            return CreatedAtAction(nameof(GetById), new { Id = GasCleanerModel.GasCleanerID }, GasCleanerModel.ToGasCleanerDTO());
        }

        [HttpPut("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateGasCleanerRequestDTO UpdateGasCleanerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (UpdateGasCleanerDTO.StationaryIZAVToOut == null || !await _stationaryIZAVRepo.StationaryIZAVExists(UpdateGasCleanerDTO.StationaryIZAVToOut.Value))
            {
                return NotFound("Stationary IZAV is not found");
            }

            if (UpdateGasCleanerDTO.SectorID == null || !await _sectorRepo.SectorExists(UpdateGasCleanerDTO.SectorID.Value))
            {
                return BadRequest("Sector is not found");
            }

            var GasCleanerModel = await _gasCleanerRepo.UpdateAsync(Id, UpdateGasCleanerDTO.ToGasCleanerFromUpdateDTO());

            if (GasCleanerModel == null)
            {
                return NotFound("GasCleaner is not found");
            }

            return Ok(GasCleanerModel.ToGasCleanerDTO());
        }


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
