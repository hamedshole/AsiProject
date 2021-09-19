using Asi.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Provinces.Delete
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteProvinceCommand>
    {
 
        private readonly IApplicationBusinessUnit _businessUnit;

        public DeleteItemCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(DeleteProvinceCommand request, CancellationToken cancellationToken)
        {
           await _businessUnit.Provinces.Delete(request.Id);
            return Unit.Value;
        }
    }
}
