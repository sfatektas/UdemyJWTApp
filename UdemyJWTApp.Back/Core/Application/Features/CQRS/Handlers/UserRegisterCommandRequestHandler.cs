using MediatR;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands;
using UdemyJWTApp.Back.Core.Application.Features.Enums;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class UserRegisterCommandRequestHandler : IRequestHandler<UserRegisterCommandRequest>
    {
        private readonly IUow _uow;

        public UserRegisterCommandRequestHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(UserRegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<AppUser>().CreateEntity(new AppUser()
            {
                Name = request.Name,
                Surname = request.Surname,
                Password = request.Password,
                AppRoleId = (int)RoleType.Member,
                PhoneNumber = request.PhoneNumber,
                UserName = request.Username
            });
            return Unit.Value;
        }
    }
}
