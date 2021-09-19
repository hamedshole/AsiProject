using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.UserRoles.Search
{
    public class SearchUserRoleCommandHandler : IRequestHandler<SearchUserRoleCommand , List<UserRoleModel>>
    {

        private readonly IApplicationBusinessUnit _businessUnit;

        public SearchUserRoleCommandHandler(IApplicationBusinessUnit businessUnit)
        {
          
            _businessUnit = businessUnit;
        }

        public  async Task<List<UserRoleModel>> Handle(SearchUserRoleCommand  request, CancellationToken cancellationToken)
        {
            return await _businessUnit.UserRoles.Search(new UserRoleModel { Title = request.Title });
        }
    }
}
