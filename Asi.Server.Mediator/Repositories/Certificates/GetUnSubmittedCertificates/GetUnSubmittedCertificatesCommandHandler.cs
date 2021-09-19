using Asi.Application.Interface;
using Asi.Domain.Common;
using Asi.Model;
using Asi.Server.Mediator.Certificates.GetUnSubmittedCertificates;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Repositories.Certificates.GetUnSubmittedCertificates
{
    public class GetUnSubmittedCertificatesCommandHandler : IRequestHandler<GetUnSubmittedCertificatesCommand, PagedList<CertificateModel>>
    {

        private readonly IApplicationBusinessUnit _businessUnit;

        public GetUnSubmittedCertificatesCommandHandler(IApplicationBusinessUnit businessUnit)
        {

            _businessUnit = businessUnit;
        }

        public async Task<PagedList<CertificateModel>> Handle(GetUnSubmittedCertificatesCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Certificates.GetUnsubmittedForms(request.PageNumber, request.PageSize);
        }
    }
}
