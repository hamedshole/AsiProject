using MediatR;

namespace Asi.Server.Mediator.Users.Delete
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; private set; }

        public DeleteUserCommand(int id)
        {
            this.Id = id;
        }
    }
}
