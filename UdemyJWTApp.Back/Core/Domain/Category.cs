namespace UdemyJWTApp.Back.Core.Domain
{
    public class Category : BaseEntity
    {
        public string? Description { get; set; }

        public List<Product> Products { get; set; }
    }
}
