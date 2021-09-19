using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.UserRoles.GetAll
{
    public class GetAllUserRoleCommand :IRequest<List<UserRoleModel>>
    {
    }
}
