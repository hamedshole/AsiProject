using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Certificates.GetNextControlById
{
    public class GetNextControlByIdCommand:IRequest<RequestCertificateModel>
    {
        public int certificateId { get; private set; }

        public GetNextControlByIdCommand(int certificateId)
        {
            this.certificateId = certificateId;
        }
    }
}
