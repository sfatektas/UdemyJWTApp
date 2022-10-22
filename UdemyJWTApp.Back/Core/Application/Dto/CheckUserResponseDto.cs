namespace UdemyJWTApp.Back.Core.Application.Dto
{
    public class CheckUserResponseDto
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public bool IsExist { get; set; }

        public string Role { get; set; } = string.Empty;
    }
}
