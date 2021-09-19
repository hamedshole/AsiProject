using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.UserRoles.Get
{
    public class GetUserRoleCommandHandler : IRequestHandler<GetUserRoleCommand, UserRoleModel>
    {
        
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetUserRoleCommandHandler(IApplicationBusinessUnit businessUnit)
        {
          
            _businessUnit = businessUnit;
        }

        public async Task<UserRoleModel> Handle(GetUserRoleCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.UserRoles.Get(request.Id);
        }
    }
}
