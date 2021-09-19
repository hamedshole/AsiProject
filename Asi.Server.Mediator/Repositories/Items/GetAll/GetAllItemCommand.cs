using Asi.Domain.Common;
using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.Items.GetAll
{
    public class GetAllItemCommand:PaginationFilter,IRequest<List<ItemModel>>
    {
    }
}
