using Asi.Domain.Common;
using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Users.SearchPaged
{
    public class SearchPagedUserCommand :PaginationFilter,IRequest<PagedList<UserModel>>
    {
        public string Username { get; private set; }

        public SearchPagedUserCommand (string username)
        {
            Username = username;
        }
    }
}
