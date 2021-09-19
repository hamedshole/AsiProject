using Asi.Model;
using System.Threading.Tasks;

namespace Asi.Application.Interface
{
    public interface IReport
    {
        Task<ControlFormReportModel> CertificateMainReport(int certificateId);
        Task<ControlFormReportModel> CertificateControlReport(int controlId);
        Task<MissMatchReportModel> CertificateMissMatchReport(int certificateId);
    }
}
