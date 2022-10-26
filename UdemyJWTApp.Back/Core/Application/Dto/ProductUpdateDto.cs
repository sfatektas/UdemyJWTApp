﻿namespace UdemyJWTApp.Back.Core.Application.Dto
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
