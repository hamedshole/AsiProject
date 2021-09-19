using Asi.Domain.Common;
using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Users.GetAllPaged
{
    public class GetAllPagedUserCommand : PaginationFilter, IRequest<PagedList<UserModel>>
    {
    }
}
