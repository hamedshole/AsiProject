using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Persons.Get
{
    public class GetPersonCommand:IRequest<PersonModel>
    {
        public int Id { get; private set; }

        public GetPersonCommand(int id)
        {
            Id = id;
        }
    }
}
