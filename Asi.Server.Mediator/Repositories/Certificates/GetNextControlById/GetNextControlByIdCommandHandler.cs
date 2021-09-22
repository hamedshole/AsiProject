using Asi.Application.Interface;
using Asi.Model;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Certificates.GetNextControlById
{
    public class GetNextControlByIdCommandHandler : IRequestHandler<GetNextControlByIdCommand, RequestCertificateModel>
    {
     
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetNextControlByIdCommandHandler(IMapper mapper, IApplicationBusinessUnit businessUnit)
        {
           
            _businessUnit = businessUnit;
        }

        public async Task<RequestCertificateModel> Handle(GetNextControlByIdCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Certificates.GetMissmatchFormById(request.certificateId);
        }
    }
}
