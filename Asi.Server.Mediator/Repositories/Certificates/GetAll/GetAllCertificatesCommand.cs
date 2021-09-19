using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.Repositories.Certificates.GetAll
{
    public class GetAllCertificatesCommand : IRequest<List<CertificateModel>>
    {
        public GetAllCertificatesCommand()
        {

        }
    }
}
