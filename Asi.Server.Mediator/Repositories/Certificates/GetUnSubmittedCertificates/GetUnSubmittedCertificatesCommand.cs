using Asi.Domain.Common;
using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Certificates.GetUnSubmittedCertificates
{
    public class GetUnSubmittedCertificatesCommand:PaginationFilter, IRequest<PagedList<CertificateModel>>
    {
    }
}
