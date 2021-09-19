using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.UserRoles.GetAll
{
    public class GetAllUserRoleCommandHandler : IRequestHandler<GetAllUserRoleCommand , List<UserRoleModel>>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetAllUserRoleCommandHandler(IApplicationBusinessUnit businessUnit)
        {
           
            _businessUnit = businessUnit;
        }

        public  async Task<List<UserRoleModel>> Handle(GetAllUserRoleCommand  request, CancellationToken cancellationToken)
        {
            return await _businessUnit.UserRoles.GetAll();
        }
    }
}
