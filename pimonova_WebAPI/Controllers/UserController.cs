using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.DTOs.User;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using static pimonova_WebAPI.Mappers.UserMappers;
using pimonova_WebAPI.DTOs.Company;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly ICompanyRepository _companyRepo;
        public UserController(IUserRepository UserRepo, ICompanyRepository CompanyRepo)
        {
            _userRepo = UserRepo;
            _companyRepo = CompanyRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Users = await _userRepo.GetAllAsync();
            var UserDTO = Users.Select(s => s.ToUserDTO());

            return Ok(Users);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var User = await _userRepo.GetByIdAsync(Id);

            if (User == null)
            {
                return NotFound("User is not found");
            }

            return Ok(User.ToUserDTO());
        }

        [HttpPost("{CompanyId:int}")]
        public async Task<IActionResult> Create([FromRoute] int CompanyId, CreateUserRequestDTO UserRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _companyRepo.CompanyExists(CompanyId))
            {
                return BadRequest("Company does not exist");
            }

            var UserModel = UserRequestDTO.ToUserFromCreateDTO(CompanyId);
            await _userRepo.CreateAsync(UserModel);

            return CreatedAtAction(nameof(GetById), new {id = UserModel.UserID}, UserModel.ToUserDTO());
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateUserRequestDTO UpdateUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var UserModel = await _userRepo.UpdateAsync(Id, UpdateUserDTO.ToUserFromUpdateDTO());

            if (UserModel == null)
            {
                return NotFound("User is not found");
            }

            return Ok(UserModel.ToUserDTO());
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var UserModel = await _userRepo.DeleteAsync(Id);

            if (UserModel == null)
            {
                return NotFound("User is not found");
            }

            return NoContent();
        }
    }
}
