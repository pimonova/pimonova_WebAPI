using Microsoft.AspNetCore.Mvc;
using pimonova_WebAPI.DTOs.User;
using pimonova_WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using pimonova_WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.DTOs.Company;
using pimonova_WebAPI.Interfaces;

namespace pimonova_WebAPI.Controllers
{
    [Route("pimonova_WebAPI/Authentication")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public struct LoginData
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private readonly IAuthRepository _authRepo;
        public AuthController(ApplicationDbContext context, IAuthRepository AuthRepo)
        {
            _authRepo = AuthRepo;
        }

        [HttpPost]
        public async Task<object> GetToken([FromBody] LoginData ld)
        {

            var User = await _authRepo.GetFromLoginAndPassword(ld.Username, ld.Password);
            if (User == null)
            {
                return Unauthorized("Login or password is incorrect");
            }

            var Identity = AuthOptions.GetIdentity(User.Login, User.Password, User);
            if (Identity == null)
            {
                return Unauthorized(); // Неверные учетные данные
            }

            // Генерируем токен
            var Token = AuthOptions.GenerateToken(User.IsAdmin);

            return Ok(Token); // Возвращаем токен
        }
    }
}