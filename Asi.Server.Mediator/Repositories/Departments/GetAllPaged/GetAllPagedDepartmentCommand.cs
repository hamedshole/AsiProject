using Asi.Domain.Common;
using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Departments.GetAllPaged
{
    public class GetAllPagedDepartmentCommand:PaginationFilter,IRequest<PagedList<DepartmentModel>>
    {
    }
}
