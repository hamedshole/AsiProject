using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Asi.Model;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Repositories.Certificates.GetAll
{
    public class GetAllCertificatesCommandHandler : IRequestHandler<GetAllCertificatesCommand, List<CertificateModel>>
    {
        private readonly IDbBusinessUnit _businessUnit;
        private readonly IMapper _mapper;
        public GetAllCertificatesCommandHandler(IDbBusinessUnit businessUnit, IMapper mapper)
        {
            _businessUnit = businessUnit;
            _mapper = mapper;
        }

        public async Task<List<CertificateModel>> Handle(GetAllCertificatesCommand request, CancellationToken cancellationToken)
        {
            List<Certificate> certificates = await _businessUnit.Certificates.GetAll();
            return await Task.Run(() => _mapper.Map<List<CertificateModel>>(certificates));
        }
    }
}
