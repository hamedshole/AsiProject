using Asi.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Provinces.Update
{
    public class UpdateProvinceCommandHandler : IRequestHandler<UpdateProvinceCommand>
    {

        private readonly IApplicationBusinessUnit _businessUnit;

        public UpdateProvinceCommandHandler(IApplicationBusinessUnit businessUnit)
        {
  
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(UpdateProvinceCommand request, CancellationToken cancellationToken)
        {
            await _businessUnit.Provinces.Update(request);
            return Unit.Value;
        }
    }
}
