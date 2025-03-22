using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Authentication
{
    public static class AuthTokenGenetator
    {
        public static readonly Guid secretKey = Guid.NewGuid();
        public static string Genetate(string _userName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey.ToString()));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                //this makes that the token is unique for each user
                new Claim(ClaimTypes.Name, _userName),
                //this is for security purpose so that a new token is genreated each time.
                new Claim(JsonWebAlgorithmsKeyTypes.RSA, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credential);

            // generates JWT token in xxx.yyy.zzz format for authentication
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
