using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.CertificateControls.GetCertificateAllControls
{
    class GetAllControlsCommandHandler : IRequestHandler<GetAllControlsCommand, List<CertificateControlModel>>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetAllControlsCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<List<CertificateControlModel>> Handle(GetAllControlsCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.CertificateControls.GetAll(request.CertificateId);

        }
    }
}
