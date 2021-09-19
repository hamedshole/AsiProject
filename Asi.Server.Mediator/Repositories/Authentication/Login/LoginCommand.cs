using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Repositories.Authentication.Login
{
    public class LoginCommand : IRequest<UserModel>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
