using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Provinces.GetAll
{
    public class GetAllProvinceCommandHandler : IRequestHandler<GetAllProvinceCommand, List<ProvinceModel>>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetAllProvinceCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public  async Task<List<ProvinceModel>> Handle(GetAllProvinceCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Provinces.GetAll();
        }
    }
}
