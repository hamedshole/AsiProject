using Asi.Application.Interface;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.CertificateTypes.CreateCertificateType
{
    public class CreateCertificateTypeHandler : IRequestHandler<CreateCertificateTypeCommand>
    {
       
        private readonly IApplicationBusinessUnit _businessUnit;

        public CreateCertificateTypeHandler(IMapper mapper, IApplicationBusinessUnit businessUnit)
        {
            
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(CreateCertificateTypeCommand request, CancellationToken cancellationToken)
        {
            await _businessUnit.CertificateTypes.Create(request);
            return Unit.Value;
        }
    }
}
