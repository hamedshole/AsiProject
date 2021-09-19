using Asi.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.ServiceTypes.Delete
{
    public class DeleteServiceTypeCommandHandler : IRequestHandler<DeleteServiceTypeCommand>
    {
        
        private readonly IApplicationBusinessUnit _businessUnit;

        public DeleteServiceTypeCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(DeleteServiceTypeCommand request, CancellationToken cancellationToken)
        {
           await _businessUnit.ServiceTypes.Delete(request.Id);
            return Unit.Value;
        }
    }
}
