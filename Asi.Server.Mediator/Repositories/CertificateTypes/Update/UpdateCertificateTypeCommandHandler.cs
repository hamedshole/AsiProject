using Asi.Application.Interface;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.CertificateTypes.UpdateCertificateType
{
    public class UpdateCertificateTypeCommandHandler : IRequestHandler<UpdateCertificateTypeCommand>
    {
        
        private readonly IApplicationBusinessUnit _businessUnit;

        public UpdateCertificateTypeCommandHandler(IMapper mapper, IApplicationBusinessUnit businessUnit)
        {
            
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(UpdateCertificateTypeCommand request, CancellationToken cancellationToken)
        {
             await _businessUnit.CertificateTypes.Update(request);
            return Unit.Value;
        }
    }
}
