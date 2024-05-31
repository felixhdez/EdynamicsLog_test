﻿using MediatR;

namespace Application.Users.Commands.CreateNewUser
{
    public class CreateNewUserCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int OrganizationId { get; set; }
    }
}
