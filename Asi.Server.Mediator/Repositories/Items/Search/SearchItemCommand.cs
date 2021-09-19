using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.Items.Search
{
    public class SearchItemCommand:IRequest<List<ItemModel>>
    {
        public string Title { get; private set; }

        public SearchItemCommand(string title)
        {
            Title = title;
        }
    }
}
