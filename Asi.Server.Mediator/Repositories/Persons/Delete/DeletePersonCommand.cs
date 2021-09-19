using MediatR;

namespace Asi.Server.Mediator.Persons.Delete
{
    public class DeletePersonCommand : IRequest
    {
        public int PersonId { get; private set; }

        public DeletePersonCommand(int id)
        {
            this.PersonId = id;
        }
    }
}
