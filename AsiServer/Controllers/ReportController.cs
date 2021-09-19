using Asi.Server.Mediator.Repositories.Reports.GetCertificateReport;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Asi.Core.Server.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("certificateReport/{certificateId}")]
        public async Task<IActionResult> GetCertificateReport(int certificateId)
        {
            try
            {
                var stream = await _mediator.Send(new GetCertificateReportCommand { CertificateId = certificateId });
                return File(stream.Data, "application/pdf");
            }
            catch (System.Exception e)
            {

                throw;
            }
        }
    }
}
