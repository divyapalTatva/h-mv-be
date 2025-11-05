using MedVault.BE.Common.Constants;
using MedVault.BE.Common.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedVault.BE.Common.Helpers
{
    public class AuthenticationHelper(IConfiguration configuration)
    {
        public string GenerateAccessToken(AuthenticationDetail authenticationDetail)
        {
            string? authenticationKey = configuration[SystemConstant.JWT_AUTHKEY] ?? string.Empty;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            string accessTokenValidity = configuration[SystemConstant.JWT_ACCESS_TOKEN_VALIDITY_IN_MINUTES] ?? string.Empty;

            List<Claim> claims =
            [
                new Claim(ClaimTypes.NameIdentifier, authenticationDetail.Id.ToString()),
                new Claim(ClaimTypes.Name, authenticationDetail.FirstName),
                new Claim(ClaimTypes.Surname, authenticationDetail.LastName),
                new Claim(ClaimTypes.Email, authenticationDetail.Email),
                new Claim(ClaimTypes.Role, Convert.ToString((int)authenticationDetail.Role)),
                new Claim(ExtraClaimType.IsProfileFilled, authenticationDetail.IsProfileFilled.ToString()),
            ];

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(accessTokenValidity)),
                SigningCredentials = credentials,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
