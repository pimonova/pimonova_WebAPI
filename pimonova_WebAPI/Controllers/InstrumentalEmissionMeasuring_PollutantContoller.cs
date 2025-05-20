using Microsoft.AspNetCore.Mvc;
using pimonova_WebAPI.DTOs.InstrumentalEmissionMeasuring_Pollutant;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Mappers;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/InstrumentalEmissionMeasurings_Pollutants")]
    [ApiController]
    public class InstrumentalEmissionMeasuring_PollutantContoller : ControllerBase
    {
        private readonly IInstrumentalEmissionMeasuring_PollutantRepository _instrumentalMeasuring_PollutantRepo;
        private readonly IPollutantRepository _pollutantRepo;
        private readonly IInstrumentalEmissionMeasuringRepository _instrumentalEmissionMeasuringRepo;
        public InstrumentalEmissionMeasuring_PollutantContoller(IInstrumentalEmissionMeasuring_PollutantRepository InstrumentalMeasuring_PollutantRepo, IInstrumentalEmissionMeasuringRepository InstrumentalEmissionMeasuringRepo, IPollutantRepository PollutantRepo)
        {
            _instrumentalEmissionMeasuringRepo = InstrumentalEmissionMeasuringRepo;
            _pollutantRepo = PollutantRepo;
            _instrumentalEmissionMeasuringRepo = InstrumentalEmissionMeasuringRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var InstrumentalEmissionMeasurings_Pollutants = await _instrumentalMeasuring_PollutantRepo.GetAllAsync();

            var InstrumentalEmissionMeasuring_PollutantDTOs = InstrumentalEmissionMeasurings_Pollutants.Select(s => s.ToInstrumentalEmissionMeasuring_PollutantDTO());

            return Ok(InstrumentalEmissionMeasuring_PollutantDTOs);
        }

        [HttpGet("{InstrumentalEmissionMeasuringId:int}/{PollutantId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int InstrumentalEmissionMeasuringId, [FromRoute] int PollutantId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var InstrumentalEmissionMeasuring_Pollutant = await _instrumentalMeasuring_PollutantRepo.GetByIdAsync(InstrumentalEmissionMeasuringId, PollutantId);

            if (InstrumentalEmissionMeasuring_Pollutant == null)
            {
                return NotFound("Instrumental emission measuring and pollutant is not found");
            }

            return Ok(InstrumentalEmissionMeasuring_Pollutant.ToInstrumentalEmissionMeasuring_PollutantDTO());
        }

        [HttpPost("{InstrumentalEmissionMeasuringId:int}/{PollutantId:int}")]
        public async Task<IActionResult> Create([FromRoute] int InstrumentalEmissionMeasuringId, [FromRoute] int PollutantId, [FromBody] CreateInstrumentalEmissionMeasuring_PollutantRequestDTO InstrumentalEmissionMeasuring_PollutantRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (InstrumentalEmissionMeasuring_PollutantRequestDTO.InstrumentalEmissionMeasuringID == null || !await _instrumentalEmissionMeasuringRepo.InstrumentalEmissionMeasuringExists(InstrumentalEmissionMeasuring_PollutantRequestDTO.InstrumentalEmissionMeasuringID.Value))
            {
                return NotFound("Instrumental emission measuring is not found");
            }

            if (InstrumentalEmissionMeasuring_PollutantRequestDTO.PollutantID == null || !await _pollutantRepo.PollutantExists(InstrumentalEmissionMeasuring_PollutantRequestDTO.PollutantID.Value))
            {
                return BadRequest("Pollutant is not found");
            }

            var InstrumentalEmissionMeasuring_PollutantModel = InstrumentalEmissionMeasuring_PollutantRequestDTO.ToInstrumentalEmissionMeasuring_PollutantFromCreateDTO(InstrumentalEmissionMeasuringId, PollutantId);

            await _instrumentalMeasuring_PollutantRepo.CreateAsync(InstrumentalEmissionMeasuring_PollutantModel);

            return CreatedAtAction(nameof(GetById), new { InstrumentalEmissionMeasuringId = InstrumentalEmissionMeasuring_PollutantModel.InstrumentalEmissionMeasuringID, PollutantId = InstrumentalEmissionMeasuring_PollutantModel.PollutantID }, InstrumentalEmissionMeasuring_PollutantModel.ToInstrumentalEmissionMeasuring_PollutantDTO());
        }

        [HttpPut("{InstrumentalEmissionMeasuringId:int}/{PollutantId:int}")]
        public async Task<IActionResult> Update([FromRoute] int InstrumentalEmissionMeasuringId, [FromRoute] int PollutantId, [FromBody] UpdateInstrumentalEmissionMeasuring_PollutantRequestDTO UpdateInstrumentalEmissionMeasuring_PollutantDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (UpdateInstrumentalEmissionMeasuring_PollutantDTO.InstrumentalEmissionMeasuringID == null || !await _instrumentalEmissionMeasuringRepo.InstrumentalEmissionMeasuringExists(UpdateInstrumentalEmissionMeasuring_PollutantDTO.InstrumentalEmissionMeasuringID.Value))
            {
                return NotFound("Instrumental emission measuring is not found");
            }

            if (UpdateInstrumentalEmissionMeasuring_PollutantDTO.PollutantID == null || !await _pollutantRepo.PollutantExists(UpdateInstrumentalEmissionMeasuring_PollutantDTO.PollutantID.Value))
            {
                return BadRequest("Pollutant is not found");
            }

            var InstrumentalEmissionMeasuring_PollutantModel = await _instrumentalMeasuring_PollutantRepo.UpdateAsync(InstrumentalEmissionMeasuringId, PollutantId, UpdateInstrumentalEmissionMeasuring_PollutantDTO.ToInstrumentalEmissionMeasuring_PollutantFromUpdateDTO());

            if (InstrumentalEmissionMeasuring_PollutantModel == null)
            {
                return NotFound("Stationary IZAV and pollutant is not found");
            }

            return Ok(InstrumentalEmissionMeasuring_PollutantModel.ToInstrumentalEmissionMeasuring_PollutantDTO());
        }


        [HttpDelete]
        [Route("{InstrumentalEmissionMeasuringId:int}/{PollutantId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int InstrumentalEmissionMeasuringId, [FromRoute] int PollutantId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var InstrumentalEmissionMeasuring_PollutantModel = await _instrumentalMeasuring_PollutantRepo.DeleteAsync(InstrumentalEmissionMeasuringId, PollutantId);

            if (InstrumentalEmissionMeasuring_PollutantModel == null)
            {
                return NotFound("Stationary IZAV and pollutant is not found");
            }

            return NoContent();
        }
    }
}
