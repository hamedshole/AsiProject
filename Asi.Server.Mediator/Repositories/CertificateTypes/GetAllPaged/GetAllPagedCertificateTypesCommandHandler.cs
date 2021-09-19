using Asi.Application.Interface;
using Asi.Domain.Common;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.CertificateTypes.GetAllPagedCertificateType
{
    public class GetAllPagedCertificateTypesCommandHandler : IRequestHandler<GetAllPagedCertificateTypesCommand, PagedList<CertificateTypeModel>>
    {
       
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetAllPagedCertificateTypesCommandHandler(IApplicationBusinessUnit businessUnit)
        {
          
            _businessUnit = businessUnit;
        }

        public async  Task<PagedList<CertificateTypeModel>> Handle(GetAllPagedCertificateTypesCommand request, CancellationToken cancellationToken)
        {
            return await  _businessUnit.CertificateTypes.GetAll(request.PageNumber, request.PageSize);
        }
    }
}
