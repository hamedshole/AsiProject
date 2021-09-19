using Asi.Model;

namespace Asi.Client.V2.Interfaces
{
    public  interface IReport
    {
      ControlFormReportModel  CertificateMainReport(int certificateId);
        ControlFormReportModel CertificateControlReport(int controlId);
        MissMatchReportModel CertificateMissMatchReport(int certificateId);
    }
}
