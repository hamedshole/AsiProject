using Asi.Domain.Common;
using Asi.Model;
using System.Collections.Generic;

namespace Asi.Client.V1.Interfaces
{
    public interface ICertificate
    {
        int UnCompleteCount();
        int LastId();
        int LastControlRepeat(int certificateId);
        void SendRequest(RequestCertificateModel controlFormSend);
        RequestCertificateModel GetMissmatchForm(int certificateId);
        PagedList<CertificateModel> GetUnsubmittedForms(int pageNumber, int pageSize);
        void SubmitCertificate(CertificateModel certificate);
        PagedList<CertificateModel> GetAll(int page, int pagesize);
        List<CertificateModel> GetAll();
        List<CertificateControlModel> GetControls(int qeueId);
        List<CertificateControlModel> GetQeueControls(int qeueId);

    }
}
