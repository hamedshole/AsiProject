using Asi.Application.Mediator.Repositories.CertificateControls.SubmitCertificateControls;
using Asi.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Repositories.CertificateControls.SubmitCertificateControls
{
    public class SubmitCertificateControlCommandHandler : IRequestHandler<SubmitCertificateControlCommand>
    {

        private readonly IApplicationBusinessUnit _businessUnit;

        public SubmitCertificateControlCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(SubmitCertificateControlCommand request, CancellationToken cancellationToken)
        {

            await _businessUnit.CertificateControls.Add(request);
            return Unit.Value;
        }
    }
}
