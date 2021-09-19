using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Items.Create
{
    public class CreateItemCommand:ItemModel,IRequest
    {
    }
}
