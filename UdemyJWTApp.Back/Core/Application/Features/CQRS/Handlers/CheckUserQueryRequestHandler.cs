using MediatR;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserQueryRequestHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IUow _uow;

        public CheckUserQueryRequestHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _uow.GetRepository<AppUser>().GetOneByFileterAsync(x => x.UserName == request.UserName && x.Password == request.Password);
            if (user.UserName == null)
            {
                return new CheckUserResponseDto()
                {
                    IsExist = false
                };
            }
            else
            {
                var role = await _uow.GetRepository<AppRole>().GetOneByFileterAsync(x => x.Id == user.AppRoleId);

                return new()
                {
                    Id = user.Id,
                    IsExist = true,
                    Role = role.Defination,
                    Username = user.UserName
                };
        }

        }
    }
}
