using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.Departments.Search
{
    public class SearchDepartmentCommand:IRequest<List<DepartmentModel>>
    {
        public string Title { get; private set; }

        public SearchDepartmentCommand(string title)
        {
            Title = title;
        }
    }
}
