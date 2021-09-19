using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Repositories.Authentication.Register
{

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public RegisterCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            await _businessUnit.Authentication.Register(new UserModel { Username = request.Username, Password = request.Password, RoleId = request.Role, PersonId = request.Person });
            return Unit.Value;
        }
    }
}
