namespace UdemyJWTApp.Back.Core.Domain
{
    public class AppUser : BaseEntity
    {
        public string? Name { get; set; }

        public string? Surname  { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Password { get; set; }

        public int AppRoleId { get; set; }

        public AppRole AppRole { get; set; } = new AppRole();
    }
}
