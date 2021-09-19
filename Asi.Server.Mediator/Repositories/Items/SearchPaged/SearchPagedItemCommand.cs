using Asi.Domain.Common;
using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Items.SearchPaged
{
    public class SearchPagedItemCommand:PaginationFilter,IRequest<PagedList<ItemModel>>
    {
        public string Title { get; private set; }

        public SearchPagedItemCommand(string title)
        {
            Title = title;
        }
    }
}
