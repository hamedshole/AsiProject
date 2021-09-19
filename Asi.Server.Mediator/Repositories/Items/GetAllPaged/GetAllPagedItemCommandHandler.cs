using Asi.Application.Interface;
using Asi.Domain.Common;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Items.GetAllPaged
{
    public class GetAllPagedItemCommandHandler : IRequestHandler<GetAllPagedItemCommand, PagedList<ItemModel>>
    {
        
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetAllPagedItemCommandHandler(IApplicationBusinessUnit businessUnit)
        {
           
            _businessUnit = businessUnit;
        }

        public async Task<PagedList<ItemModel>> Handle(GetAllPagedItemCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Items.GetAll(request.PageNumber, request.PageSize);
        }
    }
}
