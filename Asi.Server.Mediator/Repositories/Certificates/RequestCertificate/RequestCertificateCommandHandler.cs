using Asi.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Certificates.RequestCertificate
{
    public class RequestCertificateCommandHandler : IRequestHandler<RequestCertificateCommand>
    {
      
        private readonly IApplicationBusinessUnit _businessUnit;

        public RequestCertificateCommandHandler( IApplicationBusinessUnit unit)
        {
           
            _businessUnit = unit;
        }

        public async Task<Unit> Handle(RequestCertificateCommand request, CancellationToken cancellationToken)
        {
            await _businessUnit.Certificates.SendRequest(request);
            return Unit.Value;
            
        }
    }
}
