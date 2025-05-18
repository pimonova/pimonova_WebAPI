using Microsoft.AspNetCore.Mvc;
using pimonova_WebAPI.DTOs.ResultOfGasCleanersInspection;
using pimonova_WebAPI.Mappers;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/ResultOfGasCleanersInspection")]
    [ApiController]
    public class ResultOfGasCleanersInspectionController : ControllerBase
    {
        private readonly IResultOfGasCleanersInspectionRepository _resultOfGasCleanersInspectionRepo;
        private readonly IGasCleanerRepository _gasCleanerRepo;
        public ResultOfGasCleanersInspectionController(IResultOfGasCleanersInspectionRepository ResultOfGasCleanersInspectionRepo, IGasCleanerRepository GasCleanerRepo)
        {
            _resultOfGasCleanersInspectionRepo = ResultOfGasCleanersInspectionRepo;
            _gasCleanerRepo = GasCleanerRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ResultsOfGasCleanersInspection = await _resultOfGasCleanersInspectionRepo.GetAllAsync();

            var ResultsOfGasCleanersInspectionDTOs = ResultsOfGasCleanersInspection.Select(s => s.ToResultOfGasCleanersInspectionDTO());

            return Ok(ResultsOfGasCleanersInspectionDTOs);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ResultOfGasCleanersInspection = await _resultOfGasCleanersInspectionRepo.GetByIdAsync(Id);

            if (ResultOfGasCleanersInspection == null)
            {
                return NotFound("Result of gas cleaners inspection is not found");
            }

            return Ok(ResultOfGasCleanersInspection.ToResultOfGasCleanersInspectionDTO());
        }

        [HttpPost("{WorkshopId:int}")]
        public async Task<IActionResult> Create([FromRoute] int GasCleanerId, CreateResultOfGasCleanersInspectionRequestDTO ResultOfGasCleanersInspectionRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _gasCleanerRepo.GasCleanerExists(GasCleanerId))
            {
                return BadRequest("Gas cleaner does not exist");
            }

            var ResultOfGasCleanersInspectionModel = ResultOfGasCleanersInspectionRequestDTO.ToResultOfGasCleanersInspectionFromCreateDTO(GasCleanerId);
            await _resultOfGasCleanersInspectionRepo.CreateAsync(ResultOfGasCleanersInspectionModel);

            return CreatedAtAction(nameof(GetById), new { Id = ResultOfGasCleanersInspectionModel.ResultID }, ResultOfGasCleanersInspectionModel.ToResultOfGasCleanersInspectionDTO());
        }
        
        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateResultOfGasCleanersInspectionRequestDTO UpdateResultOfGasCleanersInspectionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ResultOfGasCleanersInspectionModel = await _resultOfGasCleanersInspectionRepo.UpdateAsync(Id, UpdateResultOfGasCleanersInspectionDTO.ToResultOfGasCleanersInspectionFromUpdateDTO());

            if (ResultOfGasCleanersInspectionModel == null)
            {
                return NotFound("Result of gas cleaners inspection is not found");
            }

            return Ok(ResultOfGasCleanersInspectionModel.ToResultOfGasCleanersInspectionDTO());
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ResultOfGasCleanersInspectionModel = await _resultOfGasCleanersInspectionRepo.DeleteAsync(Id);

            if (ResultOfGasCleanersInspectionModel == null)
            {
                return NotFound("Result of gas cleaners inspection is not found");
            }

            return NoContent();
        }
    }
}
