using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Items.Get
{
    public class GetItemCommandHandler : IRequestHandler<GetItemCommand, ItemModel>
    {

        private readonly IApplicationBusinessUnit _businessUnit;

        public GetItemCommandHandler(IApplicationBusinessUnit businessUnit)
        {

            _businessUnit = businessUnit;
        }

        public async Task<ItemModel> Handle(GetItemCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Items.Get(request.Id);
        }
    }
}
