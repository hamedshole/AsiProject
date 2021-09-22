using Asi.Domain.Common;
using Asi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asi.Application.Interface
{
    public interface ICertificate
    {
        Task<int> UnCompleteCertificatesCount();
        Task<int> LastId();
        Task<int> LastControlRepeat(int certificateId);
        Task SendRequest(RequestCertificateModel controlFormSend);
        Task<RequestCertificateModel> GetMissmatchFormByCompanyName(string companyName);
        Task<RequestCertificateModel> GetMissmatchFormById(int certificateId);
        Task<PagedList<CertificateModel>> GetUnsubmittedForms(int pageNumber, int pageSize);
        Task SubmitCertificate(CertificateModel certificate);
        Task<PagedList<CertificateModel>> GetAll(int page, int pagesize);
        Task<List<CertificateModel>> GetAll();
        Task<List<CertificateControlModel>> GetQeueControls(int qeueId);
        Task<List<CertificateControlModel>> GetControls(int qeueId);
    }
}
