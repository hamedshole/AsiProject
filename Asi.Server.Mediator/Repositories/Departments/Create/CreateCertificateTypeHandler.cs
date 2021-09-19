using Asi.Application.Interface;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Departments.Create
{
    public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentCommand>
    {
     
        private readonly IApplicationBusinessUnit _businessUnit;

        public CreateDepartmentHandler(IMapper mapper, IApplicationBusinessUnit businessUnit)
        {
            
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            await _businessUnit.Departments.Create(request);
            return Unit.Value;
        }
    }
}
