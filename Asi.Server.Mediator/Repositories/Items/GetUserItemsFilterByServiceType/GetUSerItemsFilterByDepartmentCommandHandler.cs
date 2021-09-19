using Asi.Application.Interface;
using Asi.Server.Mediator.Repositories.Items.GetUserItemsFilterByServiceType;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Application.Mediator.Repositories.Items.GetUserItemsFilterByServiceType
{
    public class GetUSerItemsFilterByDepartmentCommandHandler : IRequestHandler<GetUserItemsFilterByServiceTypeCommand, List<ItemModel>>
    {
        
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetUSerItemsFilterByDepartmentCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<List<ItemModel>> Handle(GetUserItemsFilterByServiceTypeCommand request, CancellationToken cancellationToken)
        {

            return await _businessUnit.Items.GetUserItemsFilterByServiceType(request.UserId, request.ServiceTypeId);
        }
    }
}
