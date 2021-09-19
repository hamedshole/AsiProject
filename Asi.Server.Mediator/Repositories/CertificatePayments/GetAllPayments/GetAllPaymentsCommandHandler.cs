using Asi.Application.Interface;
using Asi.Model;
using Asi.Server.Mediator.CertificatePayments.GetAllPayments;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Repositories.CertificatePayments.GetAllPayments
{
    public class GetAllPaymentsCommandHandler : IRequestHandler<GetAllPaymentsCommand, List<PaymentModel>>
    {

        private readonly IApplicationBusinessUnit _businessUnit;

        public GetAllPaymentsCommandHandler(IApplicationBusinessUnit businessUnit)
        {

            _businessUnit = businessUnit;
        }

        public async Task<List<PaymentModel>> Handle(GetAllPaymentsCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.CertificatePayments.GetAll(request.CertificateId);
        }
    }
}
