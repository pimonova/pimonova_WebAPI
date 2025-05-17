using Microsoft.AspNetCore.Mvc;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Mappers;
using pimonova_WebAPI.DTOs.MobileIZAV;
using pimonova_WebAPI.Models;
using pimonova_WebAPI.DTOs.Sector;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/MobileIZAVs")]
    [ApiController]
    public class MobileIZAVController : ControllerBase
    {
        private readonly IMobileIZAVRepository _mobileIZAVRepo;
        private readonly ISectorRepository _sectorRepo;
        public MobileIZAVController(IMobileIZAVRepository MobileIZAVRepo, ISectorRepository SectorRepo)
        {
            _mobileIZAVRepo = MobileIZAVRepo;
            _sectorRepo = SectorRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var MobileIZAVs = await _mobileIZAVRepo.GetAllAsync();

            var MobileIZAVsDTOs = MobileIZAVs.Select(s => s.ToMobileIZAVDTO());

            return Ok(MobileIZAVsDTOs);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var MobileIZAV = await _mobileIZAVRepo.GetByIdAsync(Id);

            if (MobileIZAV == null)
            {
                return NotFound("Mobile IZAV is not found");
            }

            return Ok(MobileIZAV.ToMobileIZAVDTO());
        }

        [HttpPost("{SectorId:int}")]
        public async Task<IActionResult> Create([FromRoute] int SectorId, CreateMobileIZAVRequestDTO MobileIZAVRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _sectorRepo.SectorExists(SectorId))
            {
                return BadRequest("Sector does not exist");
            }

            var MobileIZAVModel = MobileIZAVRequestDTO.ToMobileIZAVFromCreateDTO(SectorId);
            await _mobileIZAVRepo.CreateAsync(MobileIZAVModel);

            return CreatedAtAction(nameof(GetById), new { Id = MobileIZAVModel.MobileIZAVID }, MobileIZAVModel.ToMobileIZAVDTO());
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateMobileIZAVRequestDTO UpdateMobileIZAVDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var MobileIZAVModel = await _mobileIZAVRepo.UpdateAsync(Id, UpdateMobileIZAVDTO.ToMobileIZAVFromUpdateDTO());

            if (MobileIZAVModel == null)
            {
                return NotFound("Mobile IZAV is not found");
            }

            return Ok(MobileIZAVModel.ToMobileIZAVDTO());
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var MobileIZAVModel = await _mobileIZAVRepo.DeleteAsync(Id);

            if (MobileIZAVModel == null)
            {
                return NotFound("Mobile IZAV is not found");
            }

            return NoContent();
        }
    }
}
