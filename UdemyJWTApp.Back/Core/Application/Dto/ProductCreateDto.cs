﻿namespace UdemyJWTApp.Back.Core.Application.Dto
{
    public class ProductCreateDto
    {
        public string? Description { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

    }
}
