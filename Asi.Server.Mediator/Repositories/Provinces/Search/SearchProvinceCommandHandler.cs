using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Provinces.Search
{
    public class SearchProvinceCommandHandler : IRequestHandler<SearchProvinceCommand, List<ProvinceModel>>
    {

        private readonly IApplicationBusinessUnit _businessUnit;

        public SearchProvinceCommandHandler(IApplicationBusinessUnit businessUnit)
        {
      
            _businessUnit = businessUnit;
        }

        public  async Task<List<ProvinceModel>> Handle(SearchProvinceCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Provinces.Search(new ProvinceModel { Title = request.Title });
        }
    }
}
