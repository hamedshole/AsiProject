using Asi.Application.Interface;
using Asi.Server.Mediator.Certificates.GetLastId;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Repositories.Certificates.GetLastId
{
    public class GetLastIdCommandHandler : IRequestHandler<GetLastIdCommand, int>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetLastIdCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public Task<int> Handle(GetLastIdCommand request, CancellationToken cancellationToken)
        {
            return _businessUnit.Certificates.LastId();
        }
    }
}
