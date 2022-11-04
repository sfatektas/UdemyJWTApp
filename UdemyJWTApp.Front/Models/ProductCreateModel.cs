using Microsoft.AspNetCore.Mvc.Rendering;

namespace UdemyJWTApp.Front.Models
{
    public class ProductCreateModel
    {
        public string? Description { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public SelectList? CategorySelectList { get; set; }
    }
}
