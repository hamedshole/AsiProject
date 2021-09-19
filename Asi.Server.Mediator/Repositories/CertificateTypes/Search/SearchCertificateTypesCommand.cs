using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.CertificateTypes.SearchCertificateType
{
    public class SearchCertificateTypesCommand:IRequest<List<CertificateTypeModel>>
    {
        public string Title { get; private set; }

        public SearchCertificateTypesCommand(string title)
        {
            Title = title;
        }
    }
}
