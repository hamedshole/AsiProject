using Asi.Domain.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Certificates.GetCertificateLastControlTime
{
    public class GetCertificateControlTimeCommandHandler : IRequestHandler<GetCertificateLastControlTimeCommand, int>
    {
        private readonly IDbBusinessUnit _businessUnit;

        public GetCertificateControlTimeCommandHandler(IDbBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public Task<int> Handle(GetCertificateLastControlTimeCommand request, CancellationToken cancellationToken)
        {
            return _businessUnit.Certificates.LastControlRepeat(request.CertificateId);
        }
    }
}
