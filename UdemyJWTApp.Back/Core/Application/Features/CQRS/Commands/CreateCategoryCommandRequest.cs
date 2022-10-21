using MediatR;
using UdemyJWTApp.Back.Core.Application.Dto;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands
{
    public class CreateCategoryCommandRequest : CategoryCreateDto,IRequest
    {
    }
}
