using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Departments.GetAll
{
    public class GetAllDepartmentCommandHandler : IRequestHandler<GetAllDepartmentCommand, List<DepartmentModel>>
    {

        private readonly IApplicationBusinessUnit _businessUnit;

        public GetAllDepartmentCommandHandler(IApplicationBusinessUnit businessUnit)
        {
           
            _businessUnit = businessUnit;
        }

        public  async Task<List<DepartmentModel>> Handle(GetAllDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Departments.GetAll();
        }
    }
}
