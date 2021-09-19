using Asi.Application.Interface;
using Asi.Server.Mediator.Repositories.ServiceTypes.GetDepartmentServiceTypes;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Application.Mediator.Repositories.ServiceTypes.GetDepartmentServiceTypes
{
    public class GetDepartmentServiceTypesCommandHandler : IRequestHandler<GetDepartmeentServiceTypesCommand, List<ServiceTypeModel>>
    {
        
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetDepartmentServiceTypesCommandHandler(IApplicationBusinessUnit businessUnit)
        {
           
            _businessUnit = businessUnit;
        }

        async Task<List<ServiceTypeModel>> IRequestHandler<GetDepartmeentServiceTypesCommand, List<ServiceTypeModel>>.Handle(GetDepartmeentServiceTypesCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.ServiceTypes.GetDepartmnetServiceTypes(request.DepartmentId);
        }
    }
}
