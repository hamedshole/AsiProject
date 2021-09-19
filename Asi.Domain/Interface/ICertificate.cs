using Asi.Domain.Common;
using Asi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asi.Domain.Interface
{
    public interface ICertificate

    {
        Task<int> UnCompleteCertificateCount();
        Task<Certificate> GetNextControl(int certificateId);
        Task AddCertificateQeue(Certificate certificate);
        Task SubmitCertificate(Certificate certificate, int qeueId);
        PagedList<Certificate> GetUnSubmittedCertificates(PaginationFilter pagination);
        PagedList<Certificate> GetAll(PaginationFilter pagination);
        Task<List<Certificate>> GetAll();
        Task<List<CertificateControl>> GetCertificateQeueControls(int certificateId);
        Task<List<CertificateControl>> GetCertificateControls(int certificateId);
        Task<int> LastId();
        Task<int> LastControlRepeat(int certId);
    }
}
