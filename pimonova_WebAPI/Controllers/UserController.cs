using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.DTOs.User;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using static pimonova_WebAPI.Mappers.UserMappers;
using pimonova_WebAPI.DTOs.Company;
using pimonova_WebAPI.Helpers;
using pimonova_WebAPI.DTOs.ObjectOfNEI;
using Microsoft.AspNetCore.Identity;
using pimonova_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using pimonova_WebAPI.Repositories;

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
        public async Task<IActionResult> GetAll([FromQuery] QueryObjectForUser Query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Users = await _userRepo.GetAllAsync(Query);
            //var UserDTO = Users.Select(s => s.ToUserDTO());

            //return Ok(Users);

            var UserDTOs = Users.Select(s => s.ToUserDTO());

            return Ok(UserDTOs);
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

        [HttpPut("{id:int}/PasswordChange")]
        public async Task<IActionResult> ChangePassword(int id, [FromBody] ChangeUserPasswordRequestDTO ChangePasswordDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var UserModel = await _userRepo.GetByIdAsync(id);
            if (UserModel == null)
                return NotFound("User not found");

            var Hasher = new PasswordHasher<User>();

            // Проверка текущего пароля
            var VerificationResult = Hasher.VerifyHashedPassword(UserModel, UserModel.PasswordHash, ChangePasswordDTO.CurrentPassword);
            if (VerificationResult == PasswordVerificationResult.Failed)
                return Unauthorized("Current password is incorrect");

            // Хешируем новый пароль и сохраняем
            UserModel.PasswordHash = Hasher.HashPassword(UserModel, ChangePasswordDTO.NewPassword);
            await _userRepo.UpdatePasswordAsync(UserModel);

            return Ok("Password updated successfully");
        }

        [HttpPut("{id}/RoleChange")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> UpdateUserRole(int Id, [FromBody] UpdateUserRoleRequestDTO UpdateUserRoleDTO)
        {
            var UserModel = await _userRepo.UpdateUserRoleAsync(Id, UpdateUserRoleDTO.Role);

            if (UserModel == null)
            {
                return NotFound();
            }

            var userDto = UserModel.ToUserDTO();
            return Ok(userDto);
        }
    }
}
