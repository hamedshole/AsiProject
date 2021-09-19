using Asi.Model;
using System.Collections.Generic;

namespace Asi.Client.V2.Interfaces
{
    public interface ICertificateControl
    {
        void Add(CertificateControlModel payments);
        List<CertificateControlModel> GetAll(int certId);
        void Delete(int paymentsId);
    }
}
