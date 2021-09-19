using Asi.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.ServiceTypes.Update
{
    public class UpdateServiceTypeCommandHandler : IRequestHandler<UpdateServiceTypeCommand>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public UpdateServiceTypeCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(UpdateServiceTypeCommand request, CancellationToken cancellationToken)
        {
            await _businessUnit.ServiceTypes.Update(request);
            return Unit.Value;
        }
    }
}
