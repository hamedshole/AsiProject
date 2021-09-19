using Asi.Application.Interface;
using Asi.Server.Mediator.Repositories.Items.GetServiceTypeItems;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Application.Mediator.Repositories.Items.GetServiceTypeItems
{
    public class GetServiceTypeItemsCommandHandler : IRequestHandler<GetServiceTypeItemsCommand, List<ItemModel>>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetServiceTypeItemsCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<List<ItemModel>> Handle(GetServiceTypeItemsCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Items.GetServieTypeItems(request.Id);
        }
    }
}
