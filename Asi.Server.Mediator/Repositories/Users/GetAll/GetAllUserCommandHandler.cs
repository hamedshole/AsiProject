using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Users.GetAll
{
    public class GetAllUserCommandHandler : IRequestHandler<GetAllUserCommand , List<UserModel>>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetAllUserCommandHandler( IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public  async Task<List<UserModel>> Handle(GetAllUserCommand  request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Users.GetAll();
        }
    }
}
