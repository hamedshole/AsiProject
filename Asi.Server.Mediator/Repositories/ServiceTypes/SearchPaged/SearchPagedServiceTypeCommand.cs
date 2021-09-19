using Asi.Domain.Common;
using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.ServiceTypes.SearchPaged
{
    public class SearchPagedServiceTypeCommand :PaginationFilter,IRequest<PagedList<ServiceTypeModel>>
    {
        public string Title { get; private set; }

        public SearchPagedServiceTypeCommand (string title)
        {
            Title = title;
        }
    }
}
