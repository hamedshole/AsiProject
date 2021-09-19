using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.Users.Search
{
    public class SearchUserCommand :IRequest<List<UserModel>>
    {
        public string Title { get; private set; }

        public SearchUserCommand (string title)
        {
            Title = title;
        }
    }
}
