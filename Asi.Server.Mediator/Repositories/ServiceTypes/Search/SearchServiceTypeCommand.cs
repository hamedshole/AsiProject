using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.ServiceTypes.Search
{
    public class SearchServiceTypeCommand :IRequest<List<ServiceTypeModel>>
    {
        public string Title { get; private set; }

        public SearchServiceTypeCommand (string title)
        {
            Title = title;
        }
    }
}
