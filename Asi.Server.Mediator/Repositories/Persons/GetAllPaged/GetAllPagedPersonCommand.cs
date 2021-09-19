using Asi.Domain.Common;
using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Persons.GetAllPaged
{
    public class GetAllPagedPersonCommand : PaginationFilter, IRequest<PagedList<PersonModel>>
    {
    }
}
