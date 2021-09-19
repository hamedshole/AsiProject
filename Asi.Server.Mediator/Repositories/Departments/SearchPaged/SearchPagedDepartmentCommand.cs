using Asi.Domain.Common;
using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Departments.SearchPaged
{
    public class SearchPagedDepartmentCommand:PaginationFilter,IRequest<PagedList<DepartmentModel>>
    {
        public string Title { get; private set; }

        public SearchPagedDepartmentCommand(string title)
        {
            Title = title;
        }
    }
}
