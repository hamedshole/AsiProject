using Asi.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Departments.Delete
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand>
    {
        
        private readonly IApplicationBusinessUnit _businessUnit;

        public DeleteDepartmentCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
           await _businessUnit.Departments.Delete(request.DepartmentId);
            return Unit.Value;
        }
    }
}
