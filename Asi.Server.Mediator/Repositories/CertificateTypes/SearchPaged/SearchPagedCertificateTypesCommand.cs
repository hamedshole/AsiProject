using Asi.Domain.Common;
using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.CertificateTypes.SearchCertificateType
{
    public class SearchPagedCertificateTypesCommand:PaginationFilter,IRequest<PagedList<CertificateTypeModel>>
    {
        public string Title { get; private set; }

        public SearchPagedCertificateTypesCommand(string title)
        {
            Title = title;
        }
    }
}
