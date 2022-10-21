using AutoMapper;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Core.Application.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductListDto>().ReverseMap();
            CreateMap<Product,ProductCreateDto>().ReverseMap();
            CreateMap<Product, CreateProductCommandRequest>().ReverseMap();
            CreateMap<CreateProductCommandRequest,ProductCreateDto>().ReverseMap();
            CreateMap<Product, UpdateProductCommandRequest>().ReverseMap();
            CreateMap<ProductUpdateDto, UpdateProductCommandRequest>().ReverseMap();

        }
    }
}
