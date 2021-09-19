using Asi.Application.Interface;
using Asi.Model;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.CertificateTypes.GetCertificateType
{
    public class GetCertificateCommandHandler : IRequestHandler<GetCertificateTypeCommand, CertificateTypeModel>
    {

        private readonly IApplicationBusinessUnit _businessUnit;

        public GetCertificateCommandHandler(IMapper mapper, IApplicationBusinessUnit businessUnit)
        {
           
            _businessUnit = businessUnit;
        }

        public async Task<CertificateTypeModel> Handle(GetCertificateTypeCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.CertificateTypes.Get(request.Id);
        }
    }
}
