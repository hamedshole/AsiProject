using Asi.Application.Interface;
using Asi.Domain.Common;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Departments.GetAllPaged
{
    public class GetAllPagedDepartmentCommandHandler : IRequestHandler<GetAllPagedDepartmentCommand, PagedList<DepartmentModel>>
    {

        private readonly IApplicationBusinessUnit _businessUnit;

        public GetAllPagedDepartmentCommandHandler(IApplicationBusinessUnit businessUnit)
        {
           
            _businessUnit = businessUnit;
        }

        public async Task<PagedList<DepartmentModel>> Handle(GetAllPagedDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Departments.GetAll(request.PageNumber, request.PageSize);
        }
    }
}
