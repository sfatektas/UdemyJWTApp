using System.Text;

namespace UdemyJWTApp.Back.Infrastructure.Tools
{
    public static class JwtTokenSettings
    {
        //ValidAudience = "http://localhost", //üreten
        //ValidIssuer = "http://localhost", //kullanan
        //ClockSkew = TimeSpan.Zero, // sunucu ile client arasındaki delay
        //ValidateLifetime = true,//Tokenin süresini doğrula 
        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sefasefasefasefa1;"))//
        public const string Audience = "http://localhost";
        public const string Issuer = "http://localhost";
        public const int Expires = 30;
        public const string Key = "sefasefasefasefa1.";

    }
}
