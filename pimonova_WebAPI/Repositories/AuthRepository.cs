using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetFromLoginAndPassword(string Usrname, string Passwrd)
        {
            //return await _context.Users.FirstOrDefaultAsync(u => u.Login == Usrname && u.PasswordHash == Passwrd);

            var User = await _context.Users.FirstOrDefaultAsync(u => u.Login == Usrname);

            if (User == null) return null;

            var Hasher = new PasswordHasher<User>();
            var Result = Hasher.VerifyHashedPassword(User, User.PasswordHash, Passwrd);

            if (Result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return User;
        }
    }
}
