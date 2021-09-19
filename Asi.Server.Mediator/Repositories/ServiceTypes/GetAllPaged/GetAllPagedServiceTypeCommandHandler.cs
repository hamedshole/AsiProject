using Asi.Application.Interface;
using Asi.Domain.Common;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.ServiceTypes.GetAllPaged
{
    public class GetAllPagedServiceTypeCommandHandler : IRequestHandler<GetAllPagedServiceTypeCommand, PagedList<ServiceTypeModel>>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetAllPagedServiceTypeCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<PagedList<ServiceTypeModel>> Handle(GetAllPagedServiceTypeCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.ServiceTypes.GetAll(request.PageNumber,request.PageSize);
        }
    }
}
