using Asi.Domain.Common;
using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.CertificateTypes.GetAllPagedCertificateType
{
    public class GetAllPagedCertificateTypesCommand:PaginationFilter,IRequest<PagedList<CertificateTypeModel>>
    {
    }
}
