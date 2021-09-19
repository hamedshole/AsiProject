using Asi.Domain.Common;
using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.UserRoles.SearchPaged
{
    public class SearchPagedUserRoleCommand :PaginationFilter,IRequest<PagedList<UserRoleModel>>
    {
        public string Title { get; private set; }

        public SearchPagedUserRoleCommand (string title)
        {
            Title = title;
        }
    }
}
