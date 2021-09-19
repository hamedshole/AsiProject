using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.CertificateTypes.GetAllCertificateType
{
    public class GetAllCertificateTypesCommandHandler : IRequestHandler<GetAllCertificateTypesCommand, List<CertificateTypeModel>>
    {
       
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetAllCertificateTypesCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public  async Task<List<CertificateTypeModel>> Handle(GetAllCertificateTypesCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.CertificateTypes.GetAll();
        }
    }
}
