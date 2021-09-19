using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.Repositories.ServiceTypes.GetDepartmentServiceTypes
{
    public class GetDepartmeentServiceTypesCommand : IRequest<List<ServiceTypeModel>>
    {
        public int DepartmentId { get; private set; }

        public GetDepartmeentServiceTypesCommand(int departmentId)
        {
            DepartmentId = departmentId;
        }
    }
}
