using Asi.Application.Interface;
using Asi.Domain.Common;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Items.SearchPaged
{
    public class SearchPagedItemCommandHandler : IRequestHandler<SearchPagedItemCommand, PagedList<ItemModel>>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public SearchPagedItemCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            
            _businessUnit = businessUnit;
        }

        public async Task<PagedList<ItemModel>> Handle(SearchPagedItemCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Items.Search(new ItemModel { Title = request.Title }, request.PageNumber, request.PageSize);
        }
    }
}
