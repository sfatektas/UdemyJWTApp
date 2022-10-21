using MediatR;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands
{
    public class DeleteProudctCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteProudctCommandRequest(int ıd)
        {
            Id = ıd;
        }
    }
}
