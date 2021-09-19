using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Users.Search
{
    public class SearchUserCommandHandler : IRequestHandler<SearchUserCommand , List<UserModel>>
    {
       
        private readonly IApplicationBusinessUnit _businessUnit;

        public SearchUserCommandHandler( IApplicationBusinessUnit businessUnit)
        {
            
            _businessUnit = businessUnit;
        }

        public  async Task<List<UserModel>> Handle(SearchUserCommand  request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Users.Search(new UserModel { Username = request.Title });
        }
    }
}
