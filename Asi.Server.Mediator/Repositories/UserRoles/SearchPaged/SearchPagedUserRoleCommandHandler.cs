using Asi.Application.Interface;
using Asi.Domain.Common;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.UserRoles.SearchPaged
{
    public class SearchPagedUserRoleCommandHandler : IRequestHandler<SearchPagedUserRoleCommand , PagedList<UserRoleModel>>
    {
      
        private readonly IApplicationBusinessUnit _businessUnit;

        public SearchPagedUserRoleCommandHandler( IApplicationBusinessUnit businessUnit)
        {
           
            _businessUnit = businessUnit;
        }

        public async Task<PagedList<UserRoleModel>> Handle(SearchPagedUserRoleCommand  request, CancellationToken cancellationToken)
        {
            return await _businessUnit.UserRoles.Search(new UserRoleModel { Title = request.Title }, request.PageNumber, request.PageSize);
        }
    }
}
