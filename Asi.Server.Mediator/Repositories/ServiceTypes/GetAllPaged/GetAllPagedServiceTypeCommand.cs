using Asi.Domain.Common;
using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.ServiceTypes.GetAllPaged
{
    public class GetAllPagedServiceTypeCommand : PaginationFilter, IRequest<PagedList<ServiceTypeModel>>
    {
    }
}
