using Asi.Application.Interface;
using Asi.Server.Mediator.Repositories.Items.GetUserItems;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Application.Mediator.Repositories.Items.GetUserItems
{
    public class GetUserItemsCommandHandler : IRequestHandler<GetUserItemsCommand, List<ItemModel>>
    {
       
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetUserItemsCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<List<ItemModel>> Handle(GetUserItemsCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Items.GetUserItems(request.Id);
        }
    }
}
