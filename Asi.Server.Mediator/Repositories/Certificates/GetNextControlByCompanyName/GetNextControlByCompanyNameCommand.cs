using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Certificates.GetNextControlByCompanyName
{
    public class GetNextControlByCompanyNameCommand:IRequest<RequestCertificateModel>
    {
        public string CompanyName { get; private set; }

        public GetNextControlByCompanyNameCommand(string companyName)
        {
            this.CompanyName = companyName;
        }
    }
}
