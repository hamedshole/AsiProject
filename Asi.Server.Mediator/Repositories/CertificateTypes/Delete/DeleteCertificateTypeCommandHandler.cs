using Asi.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.CertificateTypes.DeleteCertificateType
{
    public class DeleteCertificateTypeCommandHandler : IRequestHandler<DeleteCertificateTypeCommand>
    {

        private readonly IApplicationBusinessUnit _businessUnit;

        public DeleteCertificateTypeCommandHandler(IApplicationBusinessUnit businessUnit)
        {

            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(DeleteCertificateTypeCommand request, CancellationToken cancellationToken)
        {
            await _businessUnit.CertificateTypes.Delete(request.CertificateTypeId);
            return Unit.Value;
        }
    }
}
