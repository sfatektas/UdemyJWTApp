namespace UdemyJWTApp.Front.Models
{
    public class TokenResponseModel
    {
        public string Token { get; set; } = string.Empty;

        public DateTime ExpireDate { get; set; }
    }
}
