using MediatR;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Results;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands
{
    public class UpdateCategoryCommandRequest : CategoryUpdateDto , IRequest<UpdateCategoryCommandResult>
    {
    }
}
