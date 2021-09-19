using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.Repositories.Certificates.GetCertificateQeueControls
{
    public class GetCertificateQeueControlsCommand : IRequest<List<CertificateControlModel>>
    {
        public int QeueId { get; set; }

        public GetCertificateQeueControlsCommand(int qeueId)
        {
            QeueId = qeueId;
        }
    }
}
