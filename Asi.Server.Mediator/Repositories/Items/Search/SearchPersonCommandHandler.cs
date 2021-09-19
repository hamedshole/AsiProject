using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Items.Search
{
    public class SearchPersonCommandHandler : IRequestHandler<SearchItemCommand, List<ItemModel>>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public SearchPersonCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public  async Task<List<ItemModel>> Handle(SearchItemCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Items.Search(new ItemModel { Title = request.Title });
        }
    }
}
