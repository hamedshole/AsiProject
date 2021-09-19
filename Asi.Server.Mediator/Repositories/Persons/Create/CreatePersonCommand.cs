using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Persons.Create
{
    public class CreatePersonCommand:PersonModel,IRequest
    {
    }
}
