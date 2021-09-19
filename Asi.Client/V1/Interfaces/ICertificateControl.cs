using Asi.Model;
using System.Collections.Generic;

namespace Asi.Client.V1.Interfaces
{
    public interface ICertificateControl
    {
        void Add(CertificateControlModel payments);
        List<CertificateControlModel> GetAll(int certId);
        void Delete(int paymentsId);
    }
}
