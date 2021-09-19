using Asi.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Certificates.SubmitCertificate
{
    public class SubmitCertificateCommandHandler : IRequestHandler<SubmitCertificateCommand>
    {
        
        private readonly IApplicationBusinessUnit _businessUnit;

        public SubmitCertificateCommandHandler( IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(SubmitCertificateCommand request, CancellationToken cancellationToken)
        {
            await _businessUnit.Certificates.SubmitCertificate(request);
            return Unit.Value;
        }
    }
}
