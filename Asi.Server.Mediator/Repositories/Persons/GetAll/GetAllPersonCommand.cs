using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.Persons.GetAll
{
    public class GetAllPersonCommand:IRequest<List<PersonModel>>
    {
    }
}
