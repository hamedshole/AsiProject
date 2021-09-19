using Asi.Model;
using System.Collections.Generic;

namespace Asi.Client.V1.Interfaces
{
    public interface ICertificatePayment
    {
        void Add(PaymentModel payments);
        List<PaymentModel> GetAll(int certId);
        void Delete(int paymentsId);
    }
}
