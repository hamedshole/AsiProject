using Asi.Domain.Entities;
using System.Threading.Tasks;

namespace Asi.Domain.Interface
{
    public interface IReport
    {
        Task<Certificate> GetCertificateReport(int certificateId);
        Task<Certificate> GetCertificateMissMatchReport(int certificateId);
    }
}
