using Asi.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Repositories.Certificates.GetUnCompleteCertificateCount
{
    public class GetUnCompleteCertificatesCountCommandHandler : IRequestHandler<GetUnCompleteCertificesCountCommand, int>
    {
        private readonly IApplicationBusinessUnit _unit;

        public GetUnCompleteCertificatesCountCommandHandler(IApplicationBusinessUnit unit)
        {
            _unit = unit;
        }

        public async Task<int> Handle(GetUnCompleteCertificesCountCommand request, CancellationToken cancellationToken)
        {
            return await _unit.Certificates.UnCompleteCertificatesCount();
        }
    }
}
