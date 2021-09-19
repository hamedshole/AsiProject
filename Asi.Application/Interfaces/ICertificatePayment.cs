using Asi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asi.Application.Interface
{
    public interface ICertificatePayment
    {
        Task Add(PaymentModel payments);
        Task<List<PaymentModel>> GetAll(int certId);
        Task Delete(int paymentsId);
    }
}
