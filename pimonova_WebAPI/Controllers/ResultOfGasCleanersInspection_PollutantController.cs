using Microsoft.AspNetCore.Mvc;
using pimonova_WebAPI.DTOs.ResultOfGasCleanersInspection_Pollutant;
using pimonova_WebAPI.DTOs.StationaryIZAV_Pollutant;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Mappers;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/ResultsOfGasCleanersInspection_Pollutant")]
    [ApiController]
    public class ResultOfGasCleanersInspection_PollutantController : ControllerBase
    {

        private readonly IResultOfGasCleanersInspection_PollutantRepository _result_PollutantRepo;
        private readonly IPollutantRepository _pollutantRepo;
        private readonly IResultOfGasCleanersInspectionRepository _resultOfGasCleanersInspectionRepo;
        public ResultOfGasCleanersInspection_PollutantController(IResultOfGasCleanersInspection_PollutantRepository Result_PollutantRepo, IResultOfGasCleanersInspectionRepository ResultOfGasCleanersInspectionRepo, IPollutantRepository PollutantRepo)
        {
            _result_PollutantRepo = Result_PollutantRepo;
            _resultOfGasCleanersInspectionRepo = ResultOfGasCleanersInspectionRepo;
            _pollutantRepo = PollutantRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ResultsOfGasCleanersInspection_Pollutants = await _result_PollutantRepo.GetAllAsync();

            var StationaryIZAVs_PollutantsDTOs = ResultsOfGasCleanersInspection_Pollutants.Select(s => s.ToResultOfGasCleanersInspection_PollutantDTO());

            return Ok(StationaryIZAVs_PollutantsDTOs);
        }

        [HttpGet("{ResultOfGasCleanersInspectionId:int}/{PollutantId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int ResultOfGasCleanersInspectionId, [FromRoute] int PollutantId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ResultOfGasCleanersInspection_Pollutant = await _result_PollutantRepo.GetByIdAsync(ResultOfGasCleanersInspectionId, PollutantId);

            if (ResultOfGasCleanersInspection_Pollutant == null)
            {
                return NotFound("Result of gas cleaners inspection and pollutant is not found");
            }

            return Ok(ResultOfGasCleanersInspection_Pollutant.ToResultOfGasCleanersInspection_PollutantDTO());
        }

        [HttpPost("{ResultOfGasCleanersInspectionId:int}/{PollutantId:int}")]
        public async Task<IActionResult> Create([FromRoute] int ResultOfGasCleanersInspectionId, [FromRoute] int PollutantId, [FromBody] CreateResultOfGasCleanersInspection_PollutantRequestDTO ResultOfGasCleanersInspection_PollutantRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (ResultOfGasCleanersInspection_PollutantRequestDTO.ResultOfGasCleanersInspectionID == null || !await _resultOfGasCleanersInspectionRepo.ResultOfGasCleanersInspectionExists(ResultOfGasCleanersInspection_PollutantRequestDTO.ResultOfGasCleanersInspectionID.Value))
            {
                return NotFound("Result of gas cleaners inspection is not found");
            }

            if (ResultOfGasCleanersInspection_PollutantRequestDTO.PollutantID == null || !await _pollutantRepo.PollutantExists(ResultOfGasCleanersInspection_PollutantRequestDTO.PollutantID.Value))
            {
                return BadRequest("Pollutant is not found");
            }

            var ResultOfGasCleanersInspection_PollutantModel = ResultOfGasCleanersInspection_PollutantRequestDTO.ToResultOfGasCleanersInspection_PollutantFromCreateDTO(ResultOfGasCleanersInspectionId, PollutantId);

            await _result_PollutantRepo.CreateAsync(ResultOfGasCleanersInspection_PollutantModel);

            return CreatedAtAction(nameof(GetById), new { ResultOfGasCleanersInspectionId = ResultOfGasCleanersInspection_PollutantModel.ResultOfGasCleanersInspectionID, PollutantId = ResultOfGasCleanersInspection_PollutantModel.PollutantID }, ResultOfGasCleanersInspection_PollutantModel.ToResultOfGasCleanersInspection_PollutantDTO());
        }

        [HttpPut("{ResultOfGasCleanersInspectionId:int}/{PollutantId:int}")]
        public async Task<IActionResult> Update([FromRoute] int ResultOfGasCleanersInspectionId, [FromRoute] int PollutantId, [FromBody] UpdateResultOfGasCleanersInspection_PollutantRequestDTO UpdateResultOfGasCleanersInspection_PollutantDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (UpdateResultOfGasCleanersInspection_PollutantDTO.ResultOfGasCleanersInspectionID == null || !await _resultOfGasCleanersInspectionRepo.ResultOfGasCleanersInspectionExists(UpdateResultOfGasCleanersInspection_PollutantDTO.ResultOfGasCleanersInspectionID.Value))
            {
                return NotFound("Result of gas cleaners inspection is not found");
            }

            if (UpdateResultOfGasCleanersInspection_PollutantDTO.PollutantID == null || !await _pollutantRepo.PollutantExists(UpdateResultOfGasCleanersInspection_PollutantDTO.PollutantID.Value))
            {
                return BadRequest("Pollutant is not found");
            }

            var ResultOfGasCleanersInspection_PollutantModel = await _result_PollutantRepo.UpdateAsync(ResultOfGasCleanersInspectionId, PollutantId, UpdateResultOfGasCleanersInspection_PollutantDTO.ToResultOfGasCleanersInspection_PollutantFromUpdateDTO());

            if (ResultOfGasCleanersInspection_PollutantModel == null)
            {
                return NotFound("Result of gas cleaners inspection and pollutant is not found");
            }

            return Ok(ResultOfGasCleanersInspection_PollutantModel.ToResultOfGasCleanersInspection_PollutantDTO());
        }


        [HttpDelete]
        [Route("{ResultOfGasCleanersInspectionId:int}/{PollutantId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int ResultOfGasCleanersInspectionId, [FromRoute] int PollutantId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ResultOfGasCleanersInspection_PollutantModel = await _result_PollutantRepo.DeleteAsync(ResultOfGasCleanersInspectionId, PollutantId);

            if (ResultOfGasCleanersInspection_PollutantModel == null)
            {
                return NotFound("Result of gas cleaners inspection and pollutant is not found");
            }

            return NoContent();
        }
    }
}
