using Microsoft.AspNetCore.Mvc;
using pimonova_WebAPI.DTOs.GasCleaner;
using pimonova_WebAPI.DTOs.SourceOfPollutants;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Mappers;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/SourcesOfPollutants")]
    [ApiController]
    public class SourceOfPollutantsController : ControllerBase
    {
        private readonly ISourceOfPollutantsRepository _sourceOfPollutantsRepo;
        private readonly ISectorRepository _sectorRepo;
        private readonly IGasCleanerRepository _gasCleanerRepo;
        private readonly IModeOfIZAVWithNonStationaryEmissionsRepository _modeOfIZAVWithNonStationaryEmissionsRepo;
        private readonly IStationaryIZAVRepository _stationaryIZAVRepo;
        public SourceOfPollutantsController(ISourceOfPollutantsRepository SourceOfPollutantsRepo, ISectorRepository SectorRepo, IGasCleanerRepository GasCleanerRepo, IModeOfIZAVWithNonStationaryEmissionsRepository ModeOfIZAVWithNonStationaryEmissionsRepo, IStationaryIZAVRepository StationaryIZAVRepo)
        {
            _sourceOfPollutantsRepo = SourceOfPollutantsRepo;
            _sectorRepo = SectorRepo;
            _gasCleanerRepo = GasCleanerRepo;
            _modeOfIZAVWithNonStationaryEmissionsRepo = ModeOfIZAVWithNonStationaryEmissionsRepo;
            _stationaryIZAVRepo = StationaryIZAVRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var SourcesOfPollutants = await _sourceOfPollutantsRepo.GetAllAsync();

            var SourcesOfPollutantsDTOs = SourcesOfPollutants.Select(s => s.ToSourceOfPollutantsDTO());

            return Ok(SourcesOfPollutantsDTOs);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var SourceOfPollutants = await _sourceOfPollutantsRepo.GetByIdAsync(Id);

            if (SourceOfPollutants == null)
            {
                return NotFound("Source of pollutants is not found");
            }

            return Ok(SourceOfPollutants.ToSourceOfPollutantsDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSourceOfPollutantsRequestDTO SourceOfPollutantsRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (SourceOfPollutantsRequestDTO.GasCleanerID != null &&  !await _gasCleanerRepo.GasCleanerExists(SourceOfPollutantsRequestDTO.GasCleanerID.Value))
            {
                return NotFound("Gas cleaner is not found");
            }

            if (SourceOfPollutantsRequestDTO.SectorID == null || !await _sectorRepo.SectorExists(SourceOfPollutantsRequestDTO.SectorID.Value))
            {
                return BadRequest("Sector is not found");
            }


            if (SourceOfPollutantsRequestDTO.StationaryIZAVID == null || !await _stationaryIZAVRepo.StationaryIZAVExists(SourceOfPollutantsRequestDTO.StationaryIZAVID.Value))
            {
                return NotFound("Stationary IZAV is not found");
            }

            if (SourceOfPollutantsRequestDTO.ModeNumber != null && !await _modeOfIZAVWithNonStationaryEmissionsRepo.ModeOfIZAVWithNonStationaryEmissionsExists(SourceOfPollutantsRequestDTO.ModeNumber.Value))
            {
                return BadRequest("Mode is not found");
            }

            var SourceOfPollutantsModel = SourceOfPollutantsRequestDTO.ToSourceOfPollutantsFromCreateDTO();

            await _sourceOfPollutantsRepo.CreateAsync(SourceOfPollutantsModel);

            return CreatedAtAction(nameof(GetById), new { Id = SourceOfPollutantsModel.SourceID }, SourceOfPollutantsModel.ToSourceOfPollutantsDTO());
        }

        [HttpPut("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateSourceOfPollutantsRequestDTO UpdateSourceOfPollutantsDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (UpdateSourceOfPollutantsDTO.GasCleanerID != null && !await _gasCleanerRepo.GasCleanerExists(UpdateSourceOfPollutantsDTO.GasCleanerID.Value))
            {
                return NotFound("Gas cleaner is not found");
            }

            if (UpdateSourceOfPollutantsDTO.SectorID == null || !await _sectorRepo.SectorExists(UpdateSourceOfPollutantsDTO.SectorID.Value))
            {
                return BadRequest("Sector is not found");
            }


            if (UpdateSourceOfPollutantsDTO.StationaryIZAVID == null || !await _stationaryIZAVRepo.StationaryIZAVExists(UpdateSourceOfPollutantsDTO.StationaryIZAVID.Value))
            {
                return NotFound("Stationary IZAV is not found");
            }

            if (UpdateSourceOfPollutantsDTO.ModeNumber != null && !await _modeOfIZAVWithNonStationaryEmissionsRepo.ModeOfIZAVWithNonStationaryEmissionsExists(UpdateSourceOfPollutantsDTO.ModeNumber.Value))
            {
                return BadRequest("Mode is not found");
            }

            var SourceOfPollutantsModel = await _sourceOfPollutantsRepo.UpdateAsync(Id, UpdateSourceOfPollutantsDTO.ToSourceOfPollutantsFromUpdateDTO());

            if (SourceOfPollutantsModel == null)
            {
                return NotFound("Source of pollutants is not found");
            }

            return Ok(SourceOfPollutantsModel.ToSourceOfPollutantsDTO());
        }


        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var SourceOfPollutantsModel = await _sourceOfPollutantsRepo.DeleteAsync(Id);

            if (SourceOfPollutantsModel == null)
            {
                return NotFound("Source Of pollutants is not found");
            }

            return NoContent();
        }
    }
}
