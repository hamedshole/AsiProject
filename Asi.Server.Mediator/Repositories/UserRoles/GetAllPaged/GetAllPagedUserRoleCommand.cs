using Asi.Domain.Common;
using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.UserRoles.GetAllPaged
{
    public class GetAllPagedUserRoleCommand : PaginationFilter, IRequest<PagedList<UserRoleModel>>
    {
    }
}
