using Asi.Server.Mediator.Certificates.GetCertificateLastControlTime;
using Asi.Server.Mediator.Certificates.GetLastId;
using Asi.Server.Mediator.Certificates.GetNextControl;
using Asi.Server.Mediator.Certificates.GetUnSubmittedCertificates;
using Asi.Server.Mediator.Certificates.RequestCertificate;
using Asi.Server.Mediator.Certificates.SubmitCertificate;
using Asi.Server.Mediator.Repositories.Certificates.GetAll;
using Asi.Server.Mediator.Repositories.Certificates.GetCertificateQeueControls;
using Asi.Server.Mediator.Repositories.Certificates.GetUnCompleteCertificateCount;
using Asi.Server.Mediator.Repositories.Certificates.GetUnSubmittedControls;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asi.Core.Server.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CertificateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("uncompleteCertificatesCount")]
        public async Task<IActionResult> UnCompleteCertificatesCount()
        {
            return Ok(await this._mediator.Send(new GetUnCompleteCertificesCountCommand()));
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCertificatesCommand pagination)
        {
            try
            {
                return Ok(await _mediator.Send(pagination));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
        [HttpGet("nextcontrol/{certificateid}")]
        public async Task<IActionResult> GetNextControl(int certificateid)
        {
            try
            {
                return Ok(await _mediator.Send(new  GetNextControlCommand(certificateid)));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        [HttpGet("lastid")]
        public async Task<IActionResult> GetLastId()
        {
            try
            {
                return Ok(await _mediator.Send(new GetLastIdCommand()));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        [HttpGet("certificateLastControl/{certificateId}")]
        public async Task<IActionResult> GetCertificateLastControlTime(int certificateId)
        {
            try
            {
                return Ok(await _mediator.Send(new GetCertificateLastControlTimeCommand(certificateId)));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
      
        [HttpPost("request")]
        public async Task<IActionResult> RequestCertificate([FromBody] RequestCertificateCommand controlFormSend)
        {
            try
            {
               await _mediator.Send(controlFormSend);
                return Ok();
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
        [HttpGet("controls/{qeueid}")]
        public async Task<IActionResult> GetControls(int qeueid)
        {
            try
            {
                return Ok(await _mediator.Send(new GetCertificateQeueControlsCommand(qeueid)));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
        [HttpGet("UnSubmitted/controls/{qeueid}")]
        public async Task<IActionResult> GetUnsubmittedControls(int qeueid)
        {
            try
            {
                return Ok(await _mediator.Send(new GetUnSubmittedControlsCommand(qeueid)));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        // GET api/<CertificateController>/5
        [HttpGet("unsubmitted")]
        public async Task<IActionResult> GetUnSubmitted([FromQuery]GetUnSubmittedCertificatesCommand pagination)
        {
            try
            {
               return Ok(await _mediator.Send(pagination));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        // POST api/<CertificateController>
        [HttpPost]
        public async Task<IActionResult> SubmitCertificate([FromBody] SubmitCertificateCommand value)
        {
            try
            {
                await _mediator.Send(value);
                return Ok();
            }
            catch (Exception e)
            {

                return NotFound(e.InnerException.Message);
            }
        }

        // PUT api/<CertificateController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] string value)
        {
        }

        // DELETE api/<CertificateController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
