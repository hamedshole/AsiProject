using Asi.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.UserRoles.Create
{
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand >
    {
       
        private readonly IApplicationBusinessUnit _businessUnit;

        public CreateUserRoleCommandHandler(IApplicationBusinessUnit businessUnit)
        {
           
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(CreateUserRoleCommand  request, CancellationToken cancellationToken)
        {
            await _businessUnit.UserRoles.Create(request);
            return Unit.Value;
        }
    }
}
