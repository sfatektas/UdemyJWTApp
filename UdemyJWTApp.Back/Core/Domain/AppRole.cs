namespace UdemyJWTApp.Back.Core.Domain
{
    public class AppRole : BaseEntity
    {
        public string? Defination { get; set; }

        public List<AppUser> AppUsers { get; set; }

        public AppRole()
        {
            this.AppUsers = new List<AppUser>();
        }
    }
}
