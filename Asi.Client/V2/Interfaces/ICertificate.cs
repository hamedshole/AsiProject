using Asi.Domain.Common;
using Asi.Model;

namespace Asi.Client.V2.Interfaces
{
    public interface ICertificate
    {
        int LastId();
        int LastControlRepeat(int certificateId);
        void SendRequest(RequestCertificateModel controlFormSend);
        RequestCertificateModel GetMissmatchForm(int certificateId);
        PagedList<RequestCertificateModel> GetUnsubmittedForms(int pageNumber, int pageSize);
        void SubmitCertificate(CertificateModel certificate);
        PagedList<CertificateModel> GetAll(int page, int pagesize);
    }
}
