using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Application.Mediator.Repositories.Forms.GetItemForm
{
    public class GetItemFormCommand:IRequest<List<FormTemplateModel>>
    {
        public int ItemId { get; private set; }

        public GetItemFormCommand(int itemId)
        {
            ItemId = itemId;
        }
    }
}
