using MediatR;

namespace Asi.Server.Mediator.Items.Delete
{
    public class DeleteItemCommand : IRequest
    {
        public int Id { get; private set; }

        public DeleteItemCommand(int id)
        {
            this.Id = id;
        }
    }
}
