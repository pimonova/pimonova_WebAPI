using Microsoft.AspNetCore.Mvc;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.DTOs.ModeOfIZAVWithNonStationaryEmissions;
using pimonova_WebAPI.Mappers;
using pimonova_WebAPI.DTOs.Company;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/ModesOfIZAVWithNonStationaryEmissions")]
    [ApiController]
    public class ModeOfIZAVWithNonStationaryEmissionsController : ControllerBase
    {
        private readonly IModeOfIZAVWithNonStationaryEmissionsRepository _modeOfIZAVWithNonStationaryEmissionsRepo;
        public ModeOfIZAVWithNonStationaryEmissionsController(IModeOfIZAVWithNonStationaryEmissionsRepository ModeOfIZAVWithNonStationaryEmissionsRepo)
        {
            _modeOfIZAVWithNonStationaryEmissionsRepo = ModeOfIZAVWithNonStationaryEmissionsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ModesOfIZAVWithNonStationaryEmissions = await _modeOfIZAVWithNonStationaryEmissionsRepo.GetAllAsync();

            var ModesOfIZAVWithNonStationaryEmissionsDTOs = ModesOfIZAVWithNonStationaryEmissions.Select(s => s.ToModeOfIZAVWithNonStationaryEmissionsDTO());

            return Ok(ModesOfIZAVWithNonStationaryEmissionsDTOs);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ModeOfIZAVWithNonStationaryEmissions = await _modeOfIZAVWithNonStationaryEmissionsRepo.GetByIdAsync(Id);

            if (ModeOfIZAVWithNonStationaryEmissions == null)
            {
                return NotFound("Mode of IZAV with non-stationary emissions is not found");
            }

            return Ok(ModeOfIZAVWithNonStationaryEmissions.ToModeOfIZAVWithNonStationaryEmissionsDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrUpdateModeOfIZAVWithNonStationaryEmissionsRequestDTO ModeOfIZAVWithNonStationaryEmissionsDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ModeOfIZAVWithNonStationaryEmissionsModel = ModeOfIZAVWithNonStationaryEmissionsDTO.ToModeOfIZAVWithNonStationaryEmissionsFromCreateOrUpdateDTO();
            await _modeOfIZAVWithNonStationaryEmissionsRepo.CreateAsync(ModeOfIZAVWithNonStationaryEmissionsModel);

            return CreatedAtAction(nameof(GetById), new { Id = ModeOfIZAVWithNonStationaryEmissionsModel.ModeID }, ModeOfIZAVWithNonStationaryEmissionsModel.ToModeOfIZAVWithNonStationaryEmissionsDTO());
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] CreateOrUpdateModeOfIZAVWithNonStationaryEmissionsRequestDTO UpdateModeOfIZAVWithNonStationaryEmissionsDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ModeOfIZAVWithNonStationaryEmissionsModel = await _modeOfIZAVWithNonStationaryEmissionsRepo.UpdateAsync(Id, UpdateModeOfIZAVWithNonStationaryEmissionsDTO);

            if (ModeOfIZAVWithNonStationaryEmissionsModel == null)
            {
                return NotFound("Mode of IZAV with non-stationary emissions is not found");
            }

            return Ok(ModeOfIZAVWithNonStationaryEmissionsModel.ToModeOfIZAVWithNonStationaryEmissionsDTO());
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ModeOfIZAVWithNonStationaryEmissionsModel = await _modeOfIZAVWithNonStationaryEmissionsRepo.DeleteAsync(Id);

            if (ModeOfIZAVWithNonStationaryEmissionsModel == null)
            {
                return NotFound("Mode of IZAV with non-stationary emissions is not found");
            }

            return NoContent();
        }
    }
}
