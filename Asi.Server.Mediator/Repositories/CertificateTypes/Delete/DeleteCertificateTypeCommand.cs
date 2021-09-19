using MediatR;

namespace Asi.Server.Mediator.CertificateTypes.DeleteCertificateType
{
    public class DeleteCertificateTypeCommand : IRequest
    {
        public int CertificateTypeId { get; private set; }

        public DeleteCertificateTypeCommand(int certificateTypeId)
        {
            CertificateTypeId = certificateTypeId;
        }
    }
}
