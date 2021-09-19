using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.CertificateTypes.SearchCertificateType
{
    public class SearchCertificateTypesCommandHandler : IRequestHandler<SearchCertificateTypesCommand, List<CertificateTypeModel>>
    {
       
        private readonly IApplicationBusinessUnit _businessUnit;

        public SearchCertificateTypesCommandHandler(IApplicationBusinessUnit businessUnit)
        {
          
            _businessUnit = businessUnit;
        }

        public  async Task<List<CertificateTypeModel>> Handle(SearchCertificateTypesCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.CertificateTypes.Search(new CertificateTypeModel { Title = request.Title });
        }
    }
}
