using Asi.Application.Interface;
using Asi.Domain.Common;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Provinces.GetAllPaged
{
    public class GetAllPagedProvinceCommandHandler : IRequestHandler<GetAllPagedProvinceCommand, PagedList<ProvinceModel>>
    {
       
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetAllPagedProvinceCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<PagedList<ProvinceModel>> Handle(GetAllPagedProvinceCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Provinces.GetAll(request.PageNumber, request.PageSize);
        }
    }
}
