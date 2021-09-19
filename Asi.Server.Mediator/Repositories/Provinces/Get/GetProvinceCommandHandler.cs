using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Provinces.Get
{
    public class GetProvinceCommandHandler : IRequestHandler<GetProvinceCommand, ProvinceModel>
    {
 
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetProvinceCommandHandler(IApplicationBusinessUnit businessUnit)
        {
          
            _businessUnit = businessUnit;
        }

        public async Task<ProvinceModel> Handle(GetProvinceCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Provinces.Get(request.Id);
        }
    }
}
