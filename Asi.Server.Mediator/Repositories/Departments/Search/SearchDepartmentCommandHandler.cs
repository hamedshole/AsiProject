using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Departments.Search
{
    public class SearchDepartmentCommandHandler : IRequestHandler<SearchDepartmentCommand, List<DepartmentModel>>
    {

        private readonly IApplicationBusinessUnit _businessUnit;

        public SearchDepartmentCommandHandler(IApplicationBusinessUnit businessUnit)
        {

            _businessUnit = businessUnit;
        }

        public async Task<List<DepartmentModel>> Handle(SearchDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Departments.Search(new DepartmentModel { Title = request.Title });
        }
    }
}
