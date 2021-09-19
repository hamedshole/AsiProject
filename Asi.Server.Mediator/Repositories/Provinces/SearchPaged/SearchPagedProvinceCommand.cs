using Asi.Domain.Common;
using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Provinces.SearchPaged
{
    public class SearchPagedProvinceCommand:PaginationFilter,IRequest<PagedList<ProvinceModel>>
    {
        public string Title { get; private set; }

        public SearchPagedProvinceCommand(string title)
        {
            Title = title;
        }
    }
}
