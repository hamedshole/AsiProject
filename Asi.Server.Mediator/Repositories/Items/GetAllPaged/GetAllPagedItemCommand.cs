using Asi.Domain.Common;
using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Items.GetAllPaged
{
    public class GetAllPagedItemCommand : PaginationFilter, IRequest<PagedList<ItemModel>>
    {
    }
}
