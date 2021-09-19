using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Users.Update
{
    public class UpdateUserCommand :UserModel,IRequest
    {
    }
}
