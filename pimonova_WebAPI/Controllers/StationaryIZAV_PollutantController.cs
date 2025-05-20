using Microsoft.AspNetCore.Mvc;
using pimonova_WebAPI.DTOs.GasCleaner;
using pimonova_WebAPI.DTOs.StationaryIZAV_Pollutant;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Mappers;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/StationaryIZAVs_Pollutants")]
    [ApiController]
    public class StationaryIZAV_PollutantController : ControllerBase
    {
        private readonly IStationaryIZAV_PollutantRepository _stationaryIZAV_PollutantRepo;
        private readonly IPollutantRepository _pollutantRepo;
        private readonly IStationaryIZAVRepository _stationaryIZAVRepo;
        public StationaryIZAV_PollutantController(IStationaryIZAV_PollutantRepository StationaryIZAV_PollutantRepo, IStationaryIZAVRepository StationaryIZAVRepo, IPollutantRepository PollutantRepo)
        {
            _stationaryIZAV_PollutantRepo = StationaryIZAV_PollutantRepo;
            _pollutantRepo = PollutantRepo;
            _stationaryIZAVRepo = StationaryIZAVRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var StationaryIZAVs_Pollutants = await _stationaryIZAV_PollutantRepo.GetAllAsync();

            var StationaryIZAVs_PollutantsDTOs = StationaryIZAVs_Pollutants.Select(s => s.ToStationaryIZAV_PollutantDTO());

            return Ok(StationaryIZAVs_PollutantsDTOs);
        }

        [HttpGet("{StationaryIZAVId:int}/{PollutantId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int StationaryIZAVId, [FromRoute] int PollutantId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var StationaryIZAV_Pollutant = await _stationaryIZAV_PollutantRepo.GetByIdAsync(StationaryIZAVId, PollutantId);

            if (StationaryIZAV_Pollutant == null)
            {
                return NotFound("Stationary IZAV and pollutant is not found");
            }

            return Ok(StationaryIZAV_Pollutant.ToStationaryIZAV_PollutantDTO());
        }

        [HttpPost("{StationaryIZAVId:int}/{PollutantId:int}")]
        public async Task<IActionResult> Create([FromRoute] int StationaryIZAVId, [FromRoute] int PollutantId, [FromBody] CreateStationaryIZAV_PollutantRequestDTO StationaryIZAV_PollutantRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (StationaryIZAV_PollutantRequestDTO.StationaryIZAVID == null || !await _stationaryIZAVRepo.StationaryIZAVExists(StationaryIZAV_PollutantRequestDTO.StationaryIZAVID.Value))
            {
                return NotFound("Stationary IZAV is not found");
            }

            if (StationaryIZAV_PollutantRequestDTO.PollutantID == null || !await _pollutantRepo.PollutantExists(StationaryIZAV_PollutantRequestDTO.PollutantID.Value))
            {
                return BadRequest("Pollutant is not found");
            }

            var StationaryIZAV_PollutantModel = StationaryIZAV_PollutantRequestDTO.ToStationaryIZAV_PollutantFromCreateDTO(StationaryIZAVId, PollutantId);

            await _stationaryIZAV_PollutantRepo.CreateAsync(StationaryIZAV_PollutantModel);

            return CreatedAtAction(nameof(GetById), new { StationaryIZAVId = StationaryIZAV_PollutantModel.StationaryIZAVID, PollutantId = StationaryIZAV_PollutantModel.PollutantID }, StationaryIZAV_PollutantModel.ToStationaryIZAV_PollutantDTO());
        }

        [HttpPut("{StationaryIZAVId:int}/{PollutantId:int}")]
        public async Task<IActionResult> Update([FromRoute] int StationaryIZAVId, [FromRoute] int PollutantId, [FromBody] UpdateStationaryIZAV_PollutantRequestDTO UpdateStationaryIZAV_PollutantDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (UpdateStationaryIZAV_PollutantDTO.StationaryIZAVID == null || !await _stationaryIZAVRepo.StationaryIZAVExists(UpdateStationaryIZAV_PollutantDTO.StationaryIZAVID.Value))
            {
                return NotFound("Stationary IZAV is not found");
            }

            if (UpdateStationaryIZAV_PollutantDTO.PollutantID == null || !await _pollutantRepo.PollutantExists(UpdateStationaryIZAV_PollutantDTO.PollutantID.Value))
            {
                return BadRequest("Pollutant is not found");
            }

            var StationaryIZAV_PollutantModel = await _stationaryIZAV_PollutantRepo.UpdateAsync(StationaryIZAVId, PollutantId, UpdateStationaryIZAV_PollutantDTO.ToStationaryIZAV_PollutantFromUpdateDTO());

            if (StationaryIZAV_PollutantModel == null)
            {
                return NotFound("Stationary IZAV and pollutant is not found");
            }

            return Ok(StationaryIZAV_PollutantModel.ToStationaryIZAV_PollutantDTO());
        }


        [HttpDelete]
        [Route("{StationaryIZAVId:int}/{PollutantId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int StationaryIZAVId, [FromRoute] int PollutantId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var StationaryIZAV_PollutantModel = await _stationaryIZAV_PollutantRepo.DeleteAsync(StationaryIZAVId, PollutantId);

            if (StationaryIZAV_PollutantModel == null)
            {
                return NotFound("Stationary IZAV and pollutant is not found");
            }

            return NoContent();
        }
    }
}
