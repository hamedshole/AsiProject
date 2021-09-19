using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.Repositories.Items.GetUserItemsFilterByServiceType
{
    public class GetUserItemsFilterByServiceTypeCommand : IRequest<List<ItemModel>>
    {
        public int UserId { get; private set; }
        public int ServiceTypeId { get; private set; }

        public GetUserItemsFilterByServiceTypeCommand(int userId, int serviceTypeId)
        {
            UserId = userId;
            ServiceTypeId = serviceTypeId;
        }
    }
}
