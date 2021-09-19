using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.CertificatePayments.GetAllPayments
{
    public class GetAllPaymentsCommand : IRequest<List<PaymentModel>>
    {
        public int CertificateId { get;private  set; }

        public GetAllPaymentsCommand(int certificateId)
        {
            CertificateId = certificateId;
        }
    }
}
