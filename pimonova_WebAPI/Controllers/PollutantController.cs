using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using pimonova_WebAPI.DTOs.Pollutant;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Mappers;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/Pollutant")]
    [ApiController]
    public class PollutantController : ControllerBase
    {
        private readonly IPollutantRepository _pollutantRepo;
        public PollutantController(IPollutantRepository PollutantRepo)
        {
            _pollutantRepo = PollutantRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Pollutants = await _pollutantRepo.GetAllAsync();

            var PollutantDTOs = Pollutants.Select(s => s.ToPollutantDTO());

            return Ok(PollutantDTOs);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Pollutants = await _pollutantRepo.GetByIdAsync(Id);

            if (Pollutants == null)
            {
                return NotFound("Pollutant is not found");
            }

            return Ok(Pollutants.ToPollutantDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrUpdatePollutantRequestDTO PollutantDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var PollutantModel = PollutantDTO.ToPollutantFromCreateOrUpdateDTO();
            await _pollutantRepo.CreateAsync(PollutantModel);

            return CreatedAtAction(nameof(GetById), new { Id = PollutantModel.PollutantID }, PollutantModel.ToPollutantDTO());
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] CreateOrUpdatePollutantRequestDTO UpdatePollutantsDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var PollutantModel = await _pollutantRepo.UpdateAsync(Id, UpdatePollutantsDTO);

            if (PollutantModel == null)
            {
                return NotFound("Pollutant is not found");
            }

            return Ok(PollutantModel.ToPollutantDTO());
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var PollutantModel = await _pollutantRepo.DeleteAsync(Id);

            if (PollutantModel == null)
            {
                return NotFound("Pollutant is not found");
            }

            return NoContent();
        }

    }
}
