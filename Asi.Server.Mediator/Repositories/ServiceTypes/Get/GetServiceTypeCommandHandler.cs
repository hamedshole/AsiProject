using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.ServiceTypes.Get
{
    public class GetServiceTypeCommandHandler : IRequestHandler<GetServiceTypeCommand, ServiceTypeModel>
    {
       
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetServiceTypeCommandHandler(IApplicationBusinessUnit businessUnit)
        {
           
            _businessUnit = businessUnit;
        }

        public async Task<ServiceTypeModel> Handle(GetServiceTypeCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.ServiceTypes.Get(request.Id);
        }
    }
}
