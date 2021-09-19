using MediatR;
using Stimulsoft.Report.Mvc;

namespace Asi.Server.Mediator.Repositories.Reports.GetCertificateReport
{
    public class GetCertificateReportCommand : IRequest<StiNetCoreActionResult>
    {
        public int CertificateId { get; set; }
    }
}
