using Microsoft.AspNetCore.Mvc;
using pimonova_WebAPI.DTOs.SourceOfPollutants_Pollutant;
using pimonova_WebAPI.DTOs.StationaryIZAV_Pollutant;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Mappers;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/SourcesOfPollutants_Pollutant")]
    [ApiController]
    public class SourceOfPollutants_PollutantController : ControllerBase
    {
        private readonly ISourceOfPollutants_PollutantRepository _sourceOfPollutants_PollutantRepo;
        private readonly IPollutantRepository _pollutantRepo;
        private readonly ISourceOfPollutantsRepository _sourceOfPollutantsRepo;
        public SourceOfPollutants_PollutantController(ISourceOfPollutants_PollutantRepository SourceOfPollutants_PollutantRepo, ISourceOfPollutantsRepository SourceOfPollutantsRepo, IPollutantRepository PollutantRepo)
        {
            _sourceOfPollutantsRepo = SourceOfPollutantsRepo;
            _pollutantRepo = PollutantRepo;
            _sourceOfPollutantsRepo = SourceOfPollutantsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var SourcesOfPollutants_Pollutants = await _sourceOfPollutants_PollutantRepo.GetAllAsync();

            var SourcesOfPollutants_PollutantsDTOs = SourcesOfPollutants_Pollutants.Select(s => s.ToSourceOfPollutants_PollutantDTO());

            return Ok(SourcesOfPollutants_PollutantsDTOs);
        }

        [HttpGet("{SourceOfPollutantsId:int}/{PollutantId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int SourceOfPollutantsId, [FromRoute] int PollutantId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var SourceOfPollutants_Pollutant = await _sourceOfPollutants_PollutantRepo.GetByIdAsync(SourceOfPollutantsId, PollutantId);

            if (SourceOfPollutants_Pollutant == null)
            {
                return NotFound("Source of pollutants and pollutant is not found");
            }

            return Ok(SourceOfPollutants_Pollutant.ToSourceOfPollutants_PollutantDTO());
        }

        [HttpPost("{SourceOfPollutantsId:int}/{PollutantId:int}")]
        public async Task<IActionResult> Create([FromRoute] int SourceOfPollutantsId, [FromRoute] int PollutantId, [FromBody] CreateSourceOfPollutants_PollutantRequestDTO SourceOfPollutants_PollutantRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (SourceOfPollutants_PollutantRequestDTO.SourceOfPollutantsID == null || !await _sourceOfPollutantsRepo.SourceOfPollutantsExists(SourceOfPollutants_PollutantRequestDTO.SourceOfPollutantsID.Value))
            {
                return NotFound("Source of pollutants is not found");
            }

            if (SourceOfPollutants_PollutantRequestDTO.PollutantID == null || !await _pollutantRepo.PollutantExists(SourceOfPollutants_PollutantRequestDTO.PollutantID.Value))
            {
                return BadRequest("Pollutant is not found");
            }

            var SourceOfPollutants_PollutantModel = SourceOfPollutants_PollutantRequestDTO.ToSourceOfPollutants_PollutantFromCreateDTO(SourceOfPollutantsId, PollutantId);

            await _sourceOfPollutants_PollutantRepo.CreateAsync(SourceOfPollutants_PollutantModel);

            return CreatedAtAction(nameof(GetById), new { SourceOfPollutantsId = SourceOfPollutants_PollutantModel.SourceOfPollutantsID, PollutantId = SourceOfPollutants_PollutantModel.PollutantID }, SourceOfPollutants_PollutantModel.ToSourceOfPollutants_PollutantDTO());
        }

        [HttpPut("{SourceOfPollutantsId:int}/{PollutantId:int}")]
        public async Task<IActionResult> Update([FromRoute] int SourceOfPollutantsId, [FromRoute] int PollutantId, [FromBody] UpdateSourceOfPollutants_PollutantRequestDTO UpdateSourceOfPollutants_PollutantDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (UpdateSourceOfPollutants_PollutantDTO.SourceOfPollutantsID == null || !await _sourceOfPollutantsRepo.SourceOfPollutantsExists(UpdateSourceOfPollutants_PollutantDTO.SourceOfPollutantsID.Value))
            {
                return NotFound("Source of pollutants is not found");
            }

            if (UpdateSourceOfPollutants_PollutantDTO.PollutantID == null || !await _pollutantRepo.PollutantExists(UpdateSourceOfPollutants_PollutantDTO.PollutantID.Value))
            {
                return BadRequest("Pollutant is not found");
            }

            var SourceOfPollutants_PollutantModel = await _sourceOfPollutants_PollutantRepo.UpdateAsync(SourceOfPollutantsId, PollutantId, UpdateSourceOfPollutants_PollutantDTO.ToSourceOfPollutants_PollutantFromUpdateDTO());

            if (SourceOfPollutants_PollutantModel == null)
            {
                return NotFound("Stationary IZAV and pollutant is not found");
            }

            return Ok(SourceOfPollutants_PollutantModel.ToSourceOfPollutants_PollutantDTO());
        }


        [HttpDelete]
        [Route("{SourceOfPollutantsId:int}/{PollutantId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int SourceOfPollutantsId, [FromRoute] int PollutantId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var SourceOfPollutants_PollutantModel = await _sourceOfPollutants_PollutantRepo.DeleteAsync(SourceOfPollutantsId, PollutantId);

            if (SourceOfPollutants_PollutantModel == null)
            {
                return NotFound("Source of pollutants and pollutant is not found");
            }

            return NoContent();
        }
    }
}
