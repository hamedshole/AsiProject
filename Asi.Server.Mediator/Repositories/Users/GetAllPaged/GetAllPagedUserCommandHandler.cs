using Asi.Application.Interface;
using Asi.Domain.Common;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Users.GetAllPaged
{
    public class GetAllPagedUserCommandHandler : IRequestHandler<GetAllPagedUserCommand, PagedList<UserModel>>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetAllPagedUserCommandHandler( IApplicationBusinessUnit businessUnit)
        {
          
            _businessUnit = businessUnit;
        }

        public async Task<PagedList<UserModel>> Handle(GetAllPagedUserCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Users.GetAll(request.PageNumber, request.PageSize);
        }
    }
}
