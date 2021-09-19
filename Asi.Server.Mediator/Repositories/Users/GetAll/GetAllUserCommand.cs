using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.Users.GetAll
{
    public class GetAllUserCommand :IRequest<List<UserModel>>
    {
    }
}
