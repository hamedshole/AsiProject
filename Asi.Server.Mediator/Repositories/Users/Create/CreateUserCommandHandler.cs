using Asi.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Users.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand >
    {
      
        private readonly IApplicationBusinessUnit _businessUnit;

        public CreateUserCommandHandler(IApplicationBusinessUnit businessUnit)
        { 
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(CreateUserCommand  request, CancellationToken cancellationToken)
        {
            await _businessUnit.Users.Create(request);
            return Unit.Value;
        }
    }
}
