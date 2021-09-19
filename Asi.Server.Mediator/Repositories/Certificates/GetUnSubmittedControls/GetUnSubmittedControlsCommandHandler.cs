using Asi.Application.Interface;
using Asi.Server.Mediator.Repositories.Certificates.GetUnSubmittedControls;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Application.Mediator.Repositories.Certificates.GetUnSubmittedControls
{
    public class GetUnSubmittedControlsCommandHandler : IRequestHandler<GetUnSubmittedControlsCommand, List<CertificateControlModel>>
    {
        private readonly IApplicationBusinessUnit _unit;

        public GetUnSubmittedControlsCommandHandler(IApplicationBusinessUnit unit)
        {
            _unit = unit;
        }

        public async Task<List<CertificateControlModel>> Handle(GetUnSubmittedControlsCommand request, CancellationToken cancellationToken)
        {
            return await _unit.Certificates.GetQeueControls(request.CertificateId);
        }
    }
}
