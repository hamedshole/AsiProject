using Asi.Application.Interface;
using Asi.Domain.Common;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Provinces.SearchPaged
{
    public class SearchPagedProvinceCommandHandler : IRequestHandler<SearchPagedProvinceCommand, PagedList<ProvinceModel>>
    {
        
        private readonly IApplicationBusinessUnit _businessUnit;

        public SearchPagedProvinceCommandHandler(IApplicationBusinessUnit businessUnit)
        {
         
            _businessUnit = businessUnit;
        }

        public async Task<PagedList<ProvinceModel>> Handle(SearchPagedProvinceCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Provinces.Search(new ProvinceModel { Title = request.Title }, request.PageNumber, request.PageSize);
        }
    }
}
