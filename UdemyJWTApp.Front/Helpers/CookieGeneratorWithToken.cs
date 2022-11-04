using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Json;
using UdemyJWTApp.Front.Models;

namespace UdemyJWTApp.Front.Helpers
{
    public class CustomResponse
    {
        public CustomResponse(ClaimsPrincipal principal, AuthenticationProperties properties)
        {
            Principal = principal;
            AuthenticationProperties = properties;
        }

        public ClaimsPrincipal Principal { get; set; }

        public AuthenticationProperties AuthenticationProperties { get; set; }
    }

    public static class CookieGeneratorWithToken
    {
        public async static  Task<CustomResponse> Generate(HttpResponseMessage responseMessage)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var tokenModel = JsonSerializer.Deserialize<TokenResponseModel>(jsonData, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Herhangi bir modele deserialize ederken optionsında properynamepolicy geçilir.
            });
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            
            var token = handler.ReadJwtToken(tokenModel?.Token);

            var claims = new List<Claim>();
            foreach (var claim in token.Claims)
            {
                claims.Add(claim);
            }
            
            claims.Add(new Claim("Token", $"{tokenModel?.Token}"));

                ClaimsIdentity identity = new(claims, JwtBearerDefaults.AuthenticationScheme); // identiyt sınıfı içerisine claims verilerini atıyoruz

            return new CustomResponse(new ClaimsPrincipal(identity), new()
            {
                AllowRefresh = true,//Kullanıcı herhangi bir işlem yaptığında sitede aktif olduğunda tokenin süresi otomatik arttırılır. false yapılırsa arttırılmaz.
                ExpiresUtc = tokenModel?.ExpireDate,
                IsPersistent = true
            });

        }
    }
}
