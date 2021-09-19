using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Repositories.Certificates.GetCertificateQeueControls
{
    public class GetCertificateQeueControlsCommandHandler : IRequestHandler<GetCertificateQeueControlsCommand, List<CertificateControlModel>>
    {

        private readonly IApplicationBusinessUnit _businessUnit;

        public GetCertificateQeueControlsCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<List<CertificateControlModel>> Handle(GetCertificateQeueControlsCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Certificates.GetControls(request.QeueId);


        }
    }
}
