using Asi.Application.Interface;
using Asi.Server.Mediator.Repositories.Reports.GetCertificateReport;
using Asi.Model;
using Asi.Shared.Report;
using MediatR;
using Newtonsoft.Json;
using Stimulsoft.Report.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Application.Mediator.Repositories.Reports.GetCertificateReport
{
    public class GetCertificateReportCommandHandler : IRequestHandler<GetCertificateReportCommand, StiNetCoreActionResult>
    {
        private readonly IApplicationBusinessUnit _businessUnit;
      

        public GetCertificateReportCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;

        }



        async Task<StiNetCoreActionResult> IRequestHandler<GetCertificateReportCommand, StiNetCoreActionResult>.Handle(GetCertificateReportCommand request, CancellationToken cancellationToken)
        {
            ControlFormReportModel certificate = await _businessUnit.Report.CertificateMainReport(request.CertificateId);
            System.IO.File.WriteAllText(@"E:\reportmodel.txt", JsonConvert.SerializeObject(certificate));
            ReportDesigner reportDesigner = new ReportDesigner();
            return reportDesigner.GenerateControlReport(certificate);
        }
    }
}
