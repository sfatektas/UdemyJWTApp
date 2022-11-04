using MediatR;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands
{
    public class UserRegisterCommandRequest : IRequest
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Username { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Password { get; set; }
        //Password Hashlenecek !! 

        public int AppRoleId { get; set; }

    }
}
