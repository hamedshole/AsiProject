using Asi.Domain.Common;
using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.CertificateTypes.GetAllCertificateType
{
    public class GetAllCertificateTypesCommand:PaginationFilter,IRequest<List<CertificateTypeModel>>
    {
        
    }
}
