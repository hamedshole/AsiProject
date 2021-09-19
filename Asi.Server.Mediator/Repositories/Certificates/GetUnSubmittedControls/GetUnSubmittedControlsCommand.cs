using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.Repositories.Certificates.GetUnSubmittedControls
{
    public class GetUnSubmittedControlsCommand : IRequest<List<CertificateControlModel>>
    {
        public int CertificateId { get; set; }

        public GetUnSubmittedControlsCommand(int certificateId)
        {
            CertificateId = certificateId;
        }
    }
}
