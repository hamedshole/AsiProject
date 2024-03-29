﻿using MediatR;

namespace Asi.Server.Mediator.Repositories.Authentication.Register
{
    public class RegisterCommand : IRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public int Person { get; set; }
    }
}
