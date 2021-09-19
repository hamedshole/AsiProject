using Asi.Application.Interface;
using Asi.Model;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Users.Get
{
    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, UserModel>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetUserCommandHandler(IMapper mapper, IApplicationBusinessUnit businessUnit)
        {
            _mapper = mapper;
            _businessUnit = businessUnit;
        }

        public async Task<UserModel> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Users.Get(request.Id);
        }
    }
}
