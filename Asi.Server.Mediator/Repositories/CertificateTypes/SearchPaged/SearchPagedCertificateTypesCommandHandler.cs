using Asi.Application.Interface;
using Asi.Domain.Common;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.CertificateTypes.SearchCertificateType
{
    public class SearchPagedCertificateTypesCommandHandler : IRequestHandler<SearchPagedCertificateTypesCommand, PagedList<CertificateTypeModel>>
    {
       
        private readonly IApplicationBusinessUnit _businessUnit;

        public SearchPagedCertificateTypesCommandHandler( IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public  Task<PagedList<CertificateTypeModel>> Handle(SearchPagedCertificateTypesCommand request, CancellationToken cancellationToken)
        {
            return _businessUnit.CertificateTypes.Search(new CertificateTypeModel { Title = request.Title }, request.PageNumber, request.PageSize);
        }
    }
}
