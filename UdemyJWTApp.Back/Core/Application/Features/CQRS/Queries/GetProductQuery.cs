using MediatR;
using UdemyJWTApp.Back.Core.Application.Dto;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetProductQuery : IRequest<ProductListDto>
    {
        public int Id { get; set; }

        public GetProductQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
