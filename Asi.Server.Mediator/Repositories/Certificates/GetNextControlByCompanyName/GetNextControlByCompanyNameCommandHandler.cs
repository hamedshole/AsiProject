using Asi.Application.Interface;
using Asi.Model;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Certificates.GetNextControlByCompanyName
{
    public class GetNextControlByCompanyNameCommandHandler : IRequestHandler<GetNextControlByCompanyNameCommand, RequestCertificateModel>
    {
     
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetNextControlByCompanyNameCommandHandler(IMapper mapper, IApplicationBusinessUnit businessUnit)
        {
           
            _businessUnit = businessUnit;
        }

        public async Task<RequestCertificateModel> Handle(GetNextControlByCompanyNameCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Certificates.GetMissmatchFormByCompanyName(request.CompanyName);
        }
    }
}
