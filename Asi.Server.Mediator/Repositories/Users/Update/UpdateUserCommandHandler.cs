using Asi.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Users.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {

        private readonly IApplicationBusinessUnit _businessUnit;

        public UpdateUserCommandHandler(IApplicationBusinessUnit businessUnit)
        {

            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _businessUnit.Users.Update(request);
            return Unit.Value;
        }
    }
}
