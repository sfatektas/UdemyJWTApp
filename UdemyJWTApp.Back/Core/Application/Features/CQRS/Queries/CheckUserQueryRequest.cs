﻿using MediatR;
using UdemyJWTApp.Back.Core.Application.Dto;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries
{
    public class CheckUserQueryRequest : IRequest<CheckUserResponseDto>
    {
        public string UserName { get; set; } = string.Empty;   

        public string Password { get; set; } = string.Empty;    
    }
}
