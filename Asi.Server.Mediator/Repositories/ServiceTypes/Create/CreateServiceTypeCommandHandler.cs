using Asi.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.ServiceTypes.Create
{
    public class CreateServiceTypeCommandHandler : IRequestHandler<CreateServiceTypeCommand>
    {
    
        private readonly IApplicationBusinessUnit _businessUnit;

        public CreateServiceTypeCommandHandler(IApplicationBusinessUnit businessUnit)
        {
           
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(CreateServiceTypeCommand request, CancellationToken cancellationToken)
        {
            await _businessUnit.ServiceTypes.Create(request);
            return Unit.Value;
        }
    }
}
