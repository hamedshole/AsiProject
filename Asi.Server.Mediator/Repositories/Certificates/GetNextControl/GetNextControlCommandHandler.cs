using Asi.Application.Interface;
using Asi.Model;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Certificates.GetNextControl
{
    public class GetNextControlCommandHandler : IRequestHandler<GetNextControlCommand, RequestCertificateModel>
    {
     
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetNextControlCommandHandler(IMapper mapper, IApplicationBusinessUnit businessUnit)
        {
           
            _businessUnit = businessUnit;
        }

        public async Task<RequestCertificateModel> Handle(GetNextControlCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Certificates.GetMissmatchForm(request.certificateId);
        }
    }
}
