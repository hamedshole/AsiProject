using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Persons.Update
{
    public class UpdatePersonCommand:PersonModel,IRequest
    {
    }
}
