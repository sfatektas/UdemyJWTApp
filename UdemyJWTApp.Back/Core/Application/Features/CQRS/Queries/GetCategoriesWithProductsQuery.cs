using MediatR;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetCategoriesWithProductsQuery : IRequest<List<ProductListDto>>
    {
        public int Id { get; set; }

        public GetCategoriesWithProductsQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
