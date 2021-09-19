using Asi.Application.Interface;
using Asi.Model;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Repositories.Authentication.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, UserModel>
    {
        private readonly IApplicationBusinessUnit _businessUnit;
        private readonly IMapper _mapper;

        public LoginCommandHandler(IApplicationBusinessUnit businessUnit, IMapper mapper)
        {
            _businessUnit = businessUnit;
            _mapper = mapper;
        }

        public async Task<UserModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            UserModel user = await _businessUnit.Authentication.Login(new UserModel { Username = request.Username, Password = request.Password });
            return user;
        }
    }
}
