using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.ServiceTypes.Search
{
    public class SearchServiceTypeCommandHandler : IRequestHandler<SearchServiceTypeCommand , List<ServiceTypeModel>>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public SearchServiceTypeCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public  async Task<List<ServiceTypeModel>> Handle(SearchServiceTypeCommand  request, CancellationToken cancellationToken)
        {
            return await _businessUnit.ServiceTypes.Search(new ServiceTypeModel { Title = request.Title });
        }
    }
}
