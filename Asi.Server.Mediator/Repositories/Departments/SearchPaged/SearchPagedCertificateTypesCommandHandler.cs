using Asi.Application.Interface;
using Asi.Domain.Common;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Departments.SearchPaged
{
    public class SearchPagedDepartmentCommandHandler : IRequestHandler<SearchPagedDepartmentCommand, PagedList<DepartmentModel>>
    {
    
        private readonly IApplicationBusinessUnit _businessUnit;

        public SearchPagedDepartmentCommandHandler( IApplicationBusinessUnit businessUnit)
        {
           
            _businessUnit = businessUnit;
        }

        public async Task<PagedList<DepartmentModel>> Handle(SearchPagedDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Departments.Search(new DepartmentModel { Title = request.Title }, request.PageNumber, request.PageSize);
        }
    }
}
