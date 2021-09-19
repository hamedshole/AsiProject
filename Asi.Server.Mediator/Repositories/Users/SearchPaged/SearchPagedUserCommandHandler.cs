using Asi.Application.Interface;
using Asi.Domain.Common;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Users.SearchPaged
{
    public class SearchPagedUserCommandHandler : IRequestHandler<SearchPagedUserCommand , PagedList<UserModel>>
    {
       
        private readonly IApplicationBusinessUnit _businessUnit;

        public SearchPagedUserCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<PagedList<UserModel>> Handle(SearchPagedUserCommand  request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Users.Search(new UserModel { Username = request.Username }, request.PageNumber, request.PageSize);
        }
    }
}
