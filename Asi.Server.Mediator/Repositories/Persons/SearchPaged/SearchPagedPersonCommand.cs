using Asi.Domain.Common;
using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Persons.SearchPaged
{
    public class SearchPagedPersonCommand:PaginationFilter,IRequest<PagedList<PersonModel>>
    {
        public string Title { get; private set; }

        public SearchPagedPersonCommand(string title)
        {
            Title = title;
        }
    }
}
