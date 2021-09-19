using Asi.Application.Interface;
using Asi.Domain.Common;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.UserRoles.GetAllPaged
{
    public class GetAllPagedUserRoleCommandHandler : IRequestHandler<GetAllPagedUserRoleCommand, PagedList<UserRoleModel>>
    {

        private readonly IApplicationBusinessUnit _businessUnit;

        public GetAllPagedUserRoleCommandHandler(IApplicationBusinessUnit businessUnit)
        {
         
            _businessUnit = businessUnit;
        }

        public async Task<PagedList<UserRoleModel>> Handle(GetAllPagedUserRoleCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.UserRoles.GetAll(request.PageNumber, request.PageSize);
        }
    }
}
