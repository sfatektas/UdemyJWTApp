using Newtonsoft.Json;

namespace UdemyJWTApp.Back.Core.Domain
{
    public class Product : BaseEntity
    {
        public string? Description { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        //[JsonIgnore]
        //public Category Category
        //{
        //    get
        //    { //nullable değeri yok etmek için bir diğer yöntem
        //        return new Category();
        //    }
        //    set { } //deneyim ** set methodu belirtilmediği taktirde ef core kürüphanesi migration üretirken hata veriyor.
        //}
        public Category Category { get; set; }
    }
}
