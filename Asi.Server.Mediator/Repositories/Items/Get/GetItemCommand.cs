using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Items.Get
{
    public class GetItemCommand:IRequest<ItemModel>
    {
        public int Id { get; private set; }

        public GetItemCommand(int id)
        {
            Id = id;
        }
    }
}
