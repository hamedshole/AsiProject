using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.UserRoles.Search
{
    public class SearchUserRoleCommand :IRequest<List<UserRoleModel>>
    {
        public string Title { get; private set; }

        public SearchUserRoleCommand (string title)
        {
            Title = title;
        }
    }
}
