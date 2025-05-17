using Microsoft.AspNetCore.Mvc;
using pimonova_WebAPI.DTOs.StationaryIZAV;
using pimonova_WebAPI.DTOs.InstrumentalEmissionMeasuring;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Mappers;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/InstrumentalEmissionMeasurings")]
    [ApiController]
    public class InstrumentalEmissionMeasuringController : ControllerBase
    {
        private readonly IInstrumentalEmissionMeasuringRepository _instrumentalEmissionMeasuringRepo;
        private readonly IStationaryIZAVRepository _stationaryIZAVRepo;
        public InstrumentalEmissionMeasuringController(IInstrumentalEmissionMeasuringRepository InstrumentalEmissionMeasuringRepo, IStationaryIZAVRepository StationaryIZAVRepo)
        {
            _instrumentalEmissionMeasuringRepo = InstrumentalEmissionMeasuringRepo;
            _stationaryIZAVRepo = StationaryIZAVRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var InstrumentalEmissionMeasurings = await _instrumentalEmissionMeasuringRepo.GetAllAsync();

            var InstrumentalEmissionMeasuringsDTOs = InstrumentalEmissionMeasurings.Select(s => s.ToInstrumentalEmissionMeasuringDTO());

            return Ok(InstrumentalEmissionMeasuringsDTOs);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var InstrumentalEmissionMeasuring = await _instrumentalEmissionMeasuringRepo.GetByIdAsync(Id);

            if (InstrumentalEmissionMeasuring == null)
            {
                return NotFound("Instrumental emission measuring is not found");
            }

            return Ok(InstrumentalEmissionMeasuring.ToInstrumentalEmissionMeasuringDTO());
        }

        [HttpPost("{StationaryIZAVId:int}")]
        public async Task<IActionResult> Create([FromRoute] int StationaryIZAVId, CreateInstrumentalEmissionMeasuringRequestDTO InstrumentalEmissionMeasuringRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _stationaryIZAVRepo.StationaryIZAVExists(StationaryIZAVId))
            {
                return BadRequest("Stationary IZAV does not exist");
            }

            var InstrumentalEmissionMeasuringModel = InstrumentalEmissionMeasuringRequestDTO.ToInstrumentalEmissionMeasuringFromCreateDTO(StationaryIZAVId);
            await _instrumentalEmissionMeasuringRepo.CreateAsync(InstrumentalEmissionMeasuringModel);

            return CreatedAtAction(nameof(GetById), new { Id = InstrumentalEmissionMeasuringModel.StationaryIZAVID }, InstrumentalEmissionMeasuringModel.ToInstrumentalEmissionMeasuringDTO());
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateInstrumentalEmissionMeasuringRequestDTO UpdateInstrumentalEmissionMeasuringDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var InstrumentalEmissionMeasuringModel = await _instrumentalEmissionMeasuringRepo.UpdateAsync(Id, UpdateInstrumentalEmissionMeasuringDTO.ToInstrumentalEmissionMeasuringFromUpdateDTO());

            if (InstrumentalEmissionMeasuringModel == null)
            {
                return NotFound("Stationary IZAV is not found");
            }

            return Ok(InstrumentalEmissionMeasuringModel.ToInstrumentalEmissionMeasuringDTO());
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var InstrumentalEmissionMeasuringModel = await _instrumentalEmissionMeasuringRepo.DeleteAsync(Id);

            if (InstrumentalEmissionMeasuringModel == null)
            {
                return NotFound("Instrumental emission measuring is not found");
            }

            return NoContent();
        }
    }
}
