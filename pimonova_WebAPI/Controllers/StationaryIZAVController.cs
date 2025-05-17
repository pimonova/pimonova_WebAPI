using Microsoft.AspNetCore.Mvc;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Mappers;
using pimonova_WebAPI.DTOs.StationaryIZAV;
using pimonova_WebAPI.DTOs.Sector;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/StationaryIZAVs")]
    [ApiController]
    public class StationaryIZAVController : ControllerBase
    {
        private readonly IStationaryIZAVRepository _stationaryIZAVRepo;
        private readonly ISectorRepository _sectorRepo;
        public StationaryIZAVController(IStationaryIZAVRepository StationaryIZAVRepo, ISectorRepository SectorRepo)
        {
            _stationaryIZAVRepo = StationaryIZAVRepo;
            _sectorRepo = SectorRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var StationaryIZAVs = await _stationaryIZAVRepo.GetAllAsync();

            var StationaryIZAVsDTOs = StationaryIZAVs.Select(s => s.ToStationaryIZAVDTO());

            return Ok(StationaryIZAVsDTOs);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var StationaryIZAV = await _stationaryIZAVRepo.GetByIdAsync(Id);

            if (StationaryIZAV == null)
            {
                return NotFound("Stationary IZAV is not found");
            }

            return Ok(StationaryIZAV.ToStationaryIZAVDTO());
        }

        [HttpPost("{SectorId:int}")]
        public async Task<IActionResult> Create([FromRoute] int SectorId, CreateStationaryIZAVRequestDTO StationaryIZAVRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _sectorRepo.SectorExists(SectorId))
            {
                return BadRequest("Sector does not exist");
            }

            var StationaryIZAVModel = StationaryIZAVRequestDTO.ToStationaryIZAVFromCreateDTO(SectorId);
            await _stationaryIZAVRepo.CreateAsync(StationaryIZAVModel);

            return CreatedAtAction(nameof(GetById), new { Id = StationaryIZAVModel.StationaryIZAVID }, StationaryIZAVModel.ToStationaryIZAVDTO());
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateStationaryIZAVRequestDTO UpdateStationaryIZAVDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var StationaryIZAVModel = await _stationaryIZAVRepo.UpdateAsync(Id, UpdateStationaryIZAVDTO.ToStationaryIZAVFromUpdateDTO());

            if (StationaryIZAVModel == null)
            {
                return NotFound("Stationary IZAV is not found");
            }

            return Ok(StationaryIZAVModel.ToStationaryIZAVDTO());
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var StationaryIZAVModel = await _stationaryIZAVRepo.DeleteAsync(Id);

            if (StationaryIZAVModel == null)
            {
                return NotFound("Stationary IZAV is not found");
            }

            return NoContent();
        }
    }
}
