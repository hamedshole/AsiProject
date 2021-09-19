using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.CertificateTypes.GetCertificateType
{
    public class GetCertificateTypeCommand:IRequest<CertificateTypeModel>
    {
        public int Id { get; private set; }

        public GetCertificateTypeCommand(int title)
        {
            Id = title;
        }
    }
}
