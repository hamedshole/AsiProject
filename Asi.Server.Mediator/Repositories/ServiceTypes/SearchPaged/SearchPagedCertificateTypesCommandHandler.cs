using Asi.Application.Interface;
using Asi.Domain.Common;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.ServiceTypes.SearchPaged
{
    public class SearchPagedServiceTypeCommandHandler : IRequestHandler<SearchPagedServiceTypeCommand , PagedList<ServiceTypeModel>>
    {
       
        private readonly IApplicationBusinessUnit _businessUnit;

        public SearchPagedServiceTypeCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<PagedList<ServiceTypeModel>> Handle(SearchPagedServiceTypeCommand  request, CancellationToken cancellationToken)
        {
            return await _businessUnit.ServiceTypes.Search(new ServiceTypeModel { Title = request.Title }, request.PageNumber, request.PageSize);
        }
    }
}
