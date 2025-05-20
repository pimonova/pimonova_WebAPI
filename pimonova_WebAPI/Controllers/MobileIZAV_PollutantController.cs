using Microsoft.AspNetCore.Mvc;
using pimonova_WebAPI.DTOs.MobileIZAV_Pollutant;
using pimonova_WebAPI.DTOs.StationaryIZAV_Pollutant;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Mappers;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/MobileIZAVs_Pollutants")]
    [ApiController]
    public class MobileIZAV_PollutantController : ControllerBase
    {
        private readonly IMobileIZAV_PollutantRepository _mobileIZAV_PollutantRepo;
        private readonly IPollutantRepository _pollutantRepo;
        private readonly IMobileIZAVRepository _mobileIZAVRepo;
        public MobileIZAV_PollutantController(IMobileIZAV_PollutantRepository MobileIZAV_PollutantRepo, IMobileIZAVRepository MobileIZAVRepo, IPollutantRepository PollutantRepo)
        {
            _mobileIZAV_PollutantRepo = MobileIZAV_PollutantRepo;
            _pollutantRepo = PollutantRepo;
            _mobileIZAVRepo = MobileIZAVRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var MobileIZAVs_Pollutants = await _mobileIZAV_PollutantRepo.GetAllAsync();

            var StationaryIZAVs_PollutantsDTOs = MobileIZAVs_Pollutants.Select(s => s.ToMobileIZAV_PollutantDTO());

            return Ok(StationaryIZAVs_PollutantsDTOs);
        }

        [HttpGet("{MobileIZAVId:int}/{PollutantId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int MobileIZAVId, [FromRoute] int PollutantId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var MobileIZAV_Pollutant = await _mobileIZAV_PollutantRepo.GetByIdAsync(MobileIZAVId, PollutantId);

            if (MobileIZAV_Pollutant == null)
            {
                return NotFound("Mobile IZAV and pollutant is not found");
            }

            return Ok(MobileIZAV_Pollutant.ToMobileIZAV_PollutantDTO());
        }

        [HttpPost("{MobileIZAVId:int}/{PollutantId:int}")]
        public async Task<IActionResult> Create([FromRoute] int MobileIZAVId, [FromRoute] int PollutantId, [FromBody] CreateMobileIZAV_PollutantRequestDTO MobileIZAV_PollutantRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (MobileIZAV_PollutantRequestDTO.MobileIZAVID == null || !await _mobileIZAVRepo.MobileIZAVExists(MobileIZAV_PollutantRequestDTO.MobileIZAVID.Value))
            {
                return NotFound("Mobile IZAV is not found");
            }

            if (MobileIZAV_PollutantRequestDTO.PollutantID == null || !await _pollutantRepo.PollutantExists(MobileIZAV_PollutantRequestDTO.PollutantID.Value))
            {
                return BadRequest("Pollutant is not found");
            }

            var MobileIZAV_PollutantModel = MobileIZAV_PollutantRequestDTO.ToMobileIZAV_PollutantFromCreateDTO(MobileIZAVId, PollutantId);

            await _mobileIZAV_PollutantRepo.CreateAsync(MobileIZAV_PollutantModel);

            return CreatedAtAction(nameof(GetById), new { MobileIZAVId = MobileIZAV_PollutantModel.MobileIZAVID, PollutantId = MobileIZAV_PollutantModel.PollutantID }, MobileIZAV_PollutantModel.ToMobileIZAV_PollutantDTO());
        }

        [HttpPut("{MobileIZAVId:int}/{PollutantId:int}")]
        public async Task<IActionResult> Update([FromRoute] int MobileIZAVId, [FromRoute] int PollutantId, [FromBody] UpdateMobileIZAV_PollutantRequestDTO UpdateMobileIZAV_PollutantDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (UpdateMobileIZAV_PollutantDTO.MobileIZAVID == null || !await _mobileIZAVRepo.MobileIZAVExists(UpdateMobileIZAV_PollutantDTO.MobileIZAVID.Value))
            {
                return NotFound("Mobile IZAV is not found");
            }

            if (UpdateMobileIZAV_PollutantDTO.PollutantID == null || !await _pollutantRepo.PollutantExists(UpdateMobileIZAV_PollutantDTO.PollutantID.Value))
            {
                return BadRequest("Pollutant is not found");
            }

            var MobileIZAV_PollutantModel = await _mobileIZAV_PollutantRepo.UpdateAsync(MobileIZAVId, PollutantId, UpdateMobileIZAV_PollutantDTO.ToMobileIZAV_PollutantFromUpdateDTO());

            if (MobileIZAV_PollutantModel == null)
            {
                return NotFound("Mobile IZAV and pollutant is not found");
            }

            return Ok(MobileIZAV_PollutantModel.ToMobileIZAV_PollutantDTO());
        }


        [HttpDelete]
        [Route("{MobileIZAVId:int}/{PollutantId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int MobileIZAVId, [FromRoute] int PollutantId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var MobileIZAV_PollutantModel = await _mobileIZAV_PollutantRepo.DeleteAsync(MobileIZAVId, PollutantId);

            if (MobileIZAV_PollutantModel == null)
            {
                return NotFound("Mobile IZAV and pollutant is not found");
            }

            return NoContent();
        }
    }
}
