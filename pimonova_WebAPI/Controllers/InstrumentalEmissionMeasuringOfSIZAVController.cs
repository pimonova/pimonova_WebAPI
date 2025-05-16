using Microsoft.AspNetCore.Mvc;
using pimonova_WebAPI.DTOs.StationaryIZAV;
using pimonova_WebAPI.DTOs.InstrumentalEmissionMeasuringOfSIZAV;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Mappers;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/InstrumentalEmissionMeasuringsOfSIZAV")]
    [ApiController]
    public class InstrumentalEmissionMeasuringOfSIZAVController : ControllerBase
    {
        private readonly IInstrumentalEmissionMeasuringOfSIZAVRepository _instrumentalEmissionMeasuringOfSIZAVRepo;
        private readonly IStationaryIZAVRepository _stationaryIZAVRepo;
        public InstrumentalEmissionMeasuringOfSIZAVController(IInstrumentalEmissionMeasuringOfSIZAVRepository InstrumentalEmissionMeasuringOfSIZAVRepo, IStationaryIZAVRepository StationaryIZAVRepo)
        {
            _instrumentalEmissionMeasuringOfSIZAVRepo = InstrumentalEmissionMeasuringOfSIZAVRepo;
            _stationaryIZAVRepo = StationaryIZAVRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var InstrumentalEmissionMeasuringsOfSIZAV = await _instrumentalEmissionMeasuringOfSIZAVRepo.GetAllAsync();

            var InstrumentalEmissionMeasuringsOfSIZAVDTOs = InstrumentalEmissionMeasuringsOfSIZAV.Select(s => s.ToInstrumentalEmissionMeasuringOfSIZAVDTO());

            return Ok(InstrumentalEmissionMeasuringsOfSIZAVDTOs);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var InstrumentalEmissionMeasuringOfSIZAV = await _instrumentalEmissionMeasuringOfSIZAVRepo.GetByIdAsync(Id);

            if (InstrumentalEmissionMeasuringOfSIZAV == null)
            {
                return NotFound("Instrumental emission measuring of stationary IZAV is not found");
            }

            return Ok(InstrumentalEmissionMeasuringOfSIZAV.ToInstrumentalEmissionMeasuringOfSIZAVDTO());
        }

        [HttpPost("{StationaryIZAVId:int}")]
        public async Task<IActionResult> Create([FromRoute] int StationaryIZAVId, CreateInstrumentalEmissionMeasuringOfSIZAVRequestDTO InstrumentalEmissionMeasuringOfSIZAVRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _stationaryIZAVRepo.StationaryIZAVExists(StationaryIZAVId))
            {
                return BadRequest("Stationary IZAV does not exist");
            }

            var InstrumentalEmissionMeasuringOfSIZAVModel = InstrumentalEmissionMeasuringOfSIZAVRequestDTO.ToInstrumentalEmissionMeasuringOfSIZAVFromCreateDTO(StationaryIZAVId);
            await _instrumentalEmissionMeasuringOfSIZAVRepo.CreateAsync(InstrumentalEmissionMeasuringOfSIZAVModel);

            return CreatedAtAction(nameof(GetById), new { Id = InstrumentalEmissionMeasuringOfSIZAVModel.StationaryIZAVID }, InstrumentalEmissionMeasuringOfSIZAVModel.ToInstrumentalEmissionMeasuringOfSIZAVDTO());
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateInstrumentalEmissionMeasuringOfSIZAVRequestDTO UpdateInstrumentalEmissionMeasuringOfSIZAVDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var InstrumentalEmissionMeasuringOfSIZAVModel = await _instrumentalEmissionMeasuringOfSIZAVRepo.UpdateAsync(Id, UpdateInstrumentalEmissionMeasuringOfSIZAVDTO.ToInstrumentalEmissionMeasuringOfSIZAVFromUpdateDTO());

            if (InstrumentalEmissionMeasuringOfSIZAVModel == null)
            {
                return NotFound("Stationary IZAV is not found");
            }

            return Ok(InstrumentalEmissionMeasuringOfSIZAVModel.ToInstrumentalEmissionMeasuringOfSIZAVDTO());
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var InstrumentalEmissionMeasuringOfSIZAVModel = await _instrumentalEmissionMeasuringOfSIZAVRepo.DeleteAsync(Id);

            if (InstrumentalEmissionMeasuringOfSIZAVModel == null)
            {
                return NotFound("Instrumental emission measuring of stationary IZAV is not found");
            }

            return NoContent();
        }
    }
}
