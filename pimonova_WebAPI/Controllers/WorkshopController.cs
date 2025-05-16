using Microsoft.AspNetCore.Mvc;
using pimonova_WebAPI.DTOs.ObjectOfNEI;
using pimonova_WebAPI.DTOs.Workshop;
using pimonova_WebAPI.Helpers;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Mappers;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/Workshops")]
    [ApiController]
    public class WorkshopController : ControllerBase
    {
        private readonly IWorkshopRepository _workshopRepo;
        private readonly IObjectOfNEIRepository _objectOfNEIRepo;
        public WorkshopController(IWorkshopRepository WorkshopRepo,IObjectOfNEIRepository ObjectOfNEIRepo)
        {
           _workshopRepo = WorkshopRepo;
           _objectOfNEIRepo = ObjectOfNEIRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Workshops = await _workshopRepo.GetAllAsync();

            var WorkshopsDTOs = Workshops.Select(s => s.ToWorkshopDTO());

            return Ok(WorkshopsDTOs);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Workshop = await _workshopRepo.GetByIdAsync(Id);

            if (Workshop == null)
            {
                return NotFound("Workshop is not found");
            }

            return Ok(Workshop.ToWorkshopDTO());
        }

        [HttpPost("{ObjectOfNEIId:int}")]
        public async Task<IActionResult> Create([FromRoute] int ObjectOfNEIId, CreateWorkshopRequestDTO WorkshopRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _objectOfNEIRepo.ObjectOfNEIExists(ObjectOfNEIId))
            {
                return BadRequest("Object of negative environmental impact does not exist");
            }

            var WorkshopModel = WorkshopRequestDTO.ToWorkshopFromCreateDTO(ObjectOfNEIId);
            await _workshopRepo.CreateAsync(WorkshopModel);

            return CreatedAtAction(nameof(GetById), new {Id = WorkshopModel.ObjectOfNEIID}, WorkshopModel.ToWorkshopDTO());
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateWorkshopRequestDTO UpdateWorkshopDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var WorkshopModel = await _workshopRepo.UpdateAsync(Id, UpdateWorkshopDTO.ToWorkshopFromUpdateDTO());

            if (WorkshopModel == null)
            {
                return NotFound("Workshop is not found");
            }

            return Ok(WorkshopModel.ToWorkshopDTO());
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var WorkshopModel = await _workshopRepo.DeleteAsync(Id);

            if (WorkshopModel == null)
            {
                return NotFound("Workshop is not found");
            }

            return NoContent();
        }
    }
}
