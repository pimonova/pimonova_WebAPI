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
        public static SecurityKey KEY => new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes("My_super_puper_seeeeecret_keeeyyy-12345678!")
        );

        internal static object GenerateToken(string role)
        {
            var now = DateTime.UtcNow;

            var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, "User"),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
        };

            var identity = new ClaimsIdentity(claims, "Token",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            var jwt = new JwtSecurityToken(
                issuer: ISSUER,
                audience: AUDIENCE,
                notBefore: now,
                expires: now.AddMinutes(LifetimeInMin),
                claims: identity.Claims,
                signingCredentials: new SigningCredentials(KEY, SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new { token = encodedJwt };
        }

        internal static ClaimsIdentity GetIdentity(string username, User user)
        {
            if (user != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };

                return new ClaimsIdentity(claims, "Token",
                    ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            }

            return null;
        }
    }

}
