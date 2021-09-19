using Asi.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Provinces.Create
{
    public class CreateProvinceCommandHandler : IRequestHandler<CreateProvinceCommand>
    {
     
        private readonly IApplicationBusinessUnit _businessUnit;

        public CreateProvinceCommandHandler(IApplicationBusinessUnit businessUnit)
        {
          
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(CreateProvinceCommand request, CancellationToken cancellationToken)
        {
            await _businessUnit.Provinces.Create(request);
            return Unit.Value;
        }
    }
}
