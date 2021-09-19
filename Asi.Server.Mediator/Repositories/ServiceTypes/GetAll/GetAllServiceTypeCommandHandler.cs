using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.ServiceTypes.GetAll
{
    public class GetAllServiceTypeCommandHandler : IRequestHandler<GetAllServiceTypeCommand , List<ServiceTypeModel>>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetAllServiceTypeCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public  async Task<List<ServiceTypeModel>> Handle(GetAllServiceTypeCommand  request, CancellationToken cancellationToken)
        {
            return await _businessUnit.ServiceTypes.GetAll();
        }
    }
}
