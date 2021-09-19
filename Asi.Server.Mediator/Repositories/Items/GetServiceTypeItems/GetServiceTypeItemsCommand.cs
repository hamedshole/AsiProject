using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.Repositories.Items.GetServiceTypeItems
{
    public class GetServiceTypeItemsCommand : IRequest<List<ItemModel>>
    {
        public int Id { get; private set; }

        public GetServiceTypeItemsCommand(int id)
        {
            Id = id;
        }
    }
}
