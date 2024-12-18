using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace pimonova_WebAPI.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "AntoninaPimonova"; // издатель токена
        public const string AUDIENCE = "APIclients"; // потребитель токена
        public static int LifetimeInMin => 180;
        public static SecurityKey KEY => new SymmetricSecurityKey(Encoding.ASCII.GetBytes("My_super_puper_seeeeecret_keeeyyy-12345678!"));   // ключ для шифрации

        //public virtual ICollection<User> Users { get; set; } = new List<User>();

        internal static object GenerateToken(bool IsAdmin = false)
        {
            var Now = DateTime.UtcNow;

            var Claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, "User"),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, IsAdmin?"Admin":"User")
                };

            ClaimsIdentity Identity = new ClaimsIdentity(Claims, "Token", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                issuer: ISSUER,
                audience: AUDIENCE,
                notBefore: Now,
                expires: Now.AddMinutes(LifetimeInMin),
                claims: Identity.Claims,
                signingCredentials: new SigningCredentials(KEY, SecurityAlgorithms.HmacSha256)); ;
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new { token = encodedJwt };
        }

        internal static ClaimsIdentity GetIdentity(string Username, string Password, User User)
        {
            if (User != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, User.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, User.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если имя пользователя не найдено
            return null;
        }
    }
}
