using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.Repositories.Items.GetUserItems
{
    public class GetUserItemsCommand : IRequest<List<ItemModel>>
    {
        public int Id { get; private set; }

        public GetUserItemsCommand(int id)
        {
            Id = id;
        }
    }
}
