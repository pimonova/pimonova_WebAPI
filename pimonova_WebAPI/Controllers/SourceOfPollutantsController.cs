using Microsoft.AspNetCore.Mvc;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Mappers;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/SourcesOfPollutants")]
    [ApiController]
    public class SourceOfPollutantsController : ControllerBase
    {
        private readonly ISourceOfPollutantsRepository _sourceOfPollutantsRepo;
        private readonly ISectorRepository _sectorRepo;
        public SourceOfPollutantsController(ISourceOfPollutantsRepository SourceOfPollutantsRepo, ISectorRepository SectorRepo)
        {
            _sourceOfPollutantsRepo = SourceOfPollutantsRepo;
            _sectorRepo = SectorRepo;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    var SourcesOfPollutants = await _sourceOfPollutantsRepo.GetAllAsync();

        //    var SourcesOfPollutantsDTOs = SourcesOfPollutants.Select(s => s.ToSourceOfPollutantsDTO());

        //    return Ok(SourcesOfPollutantsDTOs);
        //}

        //[HttpGet("{Id:int}")]
        //public async Task<IActionResult> GetById([FromRoute] int Id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    var SourceOfPollutants = await _sourceOfPollutantsRepo.GetByIdAsync(Id);

        //    if (SourceOfPollutants == null)
        //    {
        //        return NotFound("Source of pollutants is not found");
        //    }

        //    return Ok(SourceOfPollutants.ToSourceOfPollutantsDTO());
        //}
    }
}
