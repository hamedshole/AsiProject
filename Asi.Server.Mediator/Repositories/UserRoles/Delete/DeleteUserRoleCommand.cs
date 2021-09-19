using MediatR;

namespace Asi.Server.Mediator.UserRoles.Delete
{
    public class DeleteUserRoleCommand : IRequest
    {
        public int Id { get; private set; }

        public DeleteUserRoleCommand(int id)
        {
            this.Id = id;
        }
    }
}
