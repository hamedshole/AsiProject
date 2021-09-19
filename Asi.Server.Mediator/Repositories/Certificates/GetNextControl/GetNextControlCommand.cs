using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Certificates.GetNextControl
{
    public class GetNextControlCommand:IRequest<RequestCertificateModel>
    {
        public int certificateId { get; private set; }

        public GetNextControlCommand(int certificateId)
        {
            this.certificateId = certificateId;
        }
    }
}
