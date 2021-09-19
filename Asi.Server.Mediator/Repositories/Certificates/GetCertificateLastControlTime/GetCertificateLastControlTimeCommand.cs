using MediatR;

namespace Asi.Server.Mediator.Certificates.GetCertificateLastControlTime
{
    public  class GetCertificateLastControlTimeCommand:IRequest<int>
    {
        public int CertificateId { get; private set; }

        public GetCertificateLastControlTimeCommand(int certificateId)
        {
            CertificateId = certificateId;
        }
    }
}
