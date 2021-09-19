using Asi.Domain.Common;
using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Provinces.GetAllPaged
{
    public class GetAllPagedProvinceCommand : PaginationFilter, IRequest<PagedList<ProvinceModel>>
    {
    }
}
