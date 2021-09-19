using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.CertificateControls.GetCertificateAllControls
{
    public class GetAllControlsCommand : IRequest<List<CertificateControlModel>>
    {
        public int CertificateId { get; private set; }

        public GetAllControlsCommand(int certificateId)
        {
            CertificateId = certificateId;
        }
    }
}
