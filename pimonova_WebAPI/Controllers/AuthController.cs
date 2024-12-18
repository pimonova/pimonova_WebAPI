using Microsoft.AspNetCore.Mvc;
using pimonova_WebAPI.DTOs.User;
using pimonova_WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using pimonova_WebAPI.Data;
using Microsoft.EntityFrameworkCore;

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

        private readonly ApplicationDbContext _context;
        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public object GetToken([FromBody] LoginData ld)
        {

            var User = _context.Users.FirstOrDefault(u => u.Login == ld.Username && u.Password == ld.Password);
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

            //return AuthOptions.GenerateToken(User.IsAdmin);
        }
    }
}