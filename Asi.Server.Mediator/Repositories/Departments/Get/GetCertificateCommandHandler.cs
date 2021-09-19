using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Departments.Get
{
    public class GetDepartmentCommandHandler : IRequestHandler<GetDepartmentCommand, DepartmentModel>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetDepartmentCommandHandler( IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<DepartmentModel> Handle(GetDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Departments.Get(request.Id);
        }
    }
}
