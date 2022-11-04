namespace UdemyJWTApp.Back.Core.Application.Dto
{
    public class ProductListDto
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        //public CategoryListDto CategoryListDto { get
        //    {
        //        return new CategoryListDto();
        //    }
        //}
    }
}
