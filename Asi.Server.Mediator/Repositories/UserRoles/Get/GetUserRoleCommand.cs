using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.UserRoles.Get
{
    public class GetUserRoleCommand :IRequest<UserRoleModel>
    {
        public int Id { get; private set; }

        public GetUserRoleCommand (int id)
        {
            Id = id;
        }
    }
}
