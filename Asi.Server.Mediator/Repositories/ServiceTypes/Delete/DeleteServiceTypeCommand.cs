using MediatR;

namespace Asi.Server.Mediator.ServiceTypes.Delete
{
    public class DeleteServiceTypeCommand : IRequest
    {
        public int Id { get; private set; }

        public DeleteServiceTypeCommand(int id)
        {
            this.Id = id;
        }
    }
}
