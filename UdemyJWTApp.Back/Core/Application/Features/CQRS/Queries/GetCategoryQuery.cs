using MediatR;
using UdemyJWTApp.Back.Core.Application.Dto;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryQuery : IRequest<CategoryListDto>
    {
        public int Id { get; set; }

        public GetCategoryQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
