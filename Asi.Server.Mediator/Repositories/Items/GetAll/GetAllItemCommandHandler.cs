using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Items.GetAll
{
    public class GetAllItemCommandHandler : IRequestHandler<GetAllItemCommand, List<ItemModel>>
    {

        private readonly IApplicationBusinessUnit _businessUnit;

        public GetAllItemCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<List<ItemModel>> Handle(GetAllItemCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Items.GetAll();
        }


    }
}
