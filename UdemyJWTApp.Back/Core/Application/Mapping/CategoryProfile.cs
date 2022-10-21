using AutoMapper;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Core.Application.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryListDto>().ReverseMap();
            CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommandRequest>().ReverseMap();
            CreateMap<CategoryCreateDto, CreateCategoryCommandRequest>().ReverseMap();
            CreateMap<CategoryUpdateDto, UpdateCategoryCommandRequest>().ReverseMap();
        }
    }
}
