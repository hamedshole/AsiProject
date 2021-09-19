using Asi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asi.Application.Interface
{
    public interface ICertificateControl
    {
        Task Add(CertificateControlModel payments);
        Task<List<CertificateControlModel>> GetAll(int certId);
        Task Delete(int paymentsId);
    }
}
