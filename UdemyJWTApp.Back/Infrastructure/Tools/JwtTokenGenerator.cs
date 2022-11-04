using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UdemyJWTApp.Back.Core.Application.Dto;

namespace UdemyJWTApp.Back.Infrastructure.Tools
{
    public class JwtTokenGenerator
    {
        public static JwtTokenResponse GenerateToken(CheckUserResponseDto dto)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSettings.Key));

            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, dto.Role)); // ? role diziside verilebilir.
            claims.Add(new Claim(ClaimTypes.Name, dto.Username));

            var expires = DateTime.UtcNow.AddMinutes(30/*JwtTokenSettings.Expires*/);

            //SigningCredeantial proportysi geçilmez ise token doğrulaması çalışmıyor. !!!!!!!!!!!!!!!!!!

            //Token Üretilirken Utc zamanı referans alınmalı herkesin ortak benimsediği saat zamanın kullanılmalı.

            JwtSecurityToken token = new(issuer: JwtTokenSettings.Issuer,audience: JwtTokenSettings.Audience,claims:claims,notBefore : DateTime.UtcNow,expires: expires,signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return new(handler.WriteToken(token),expires);
        }
    }
}
