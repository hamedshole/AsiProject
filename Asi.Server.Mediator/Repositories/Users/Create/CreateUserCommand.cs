using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Users.Create
{
    public class CreateUserCommand :UserModel,IRequest
    {
    }
}
