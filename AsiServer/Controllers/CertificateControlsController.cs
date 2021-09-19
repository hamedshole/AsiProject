using Asi.Server.Mediator.CertificateControls.GetCertificateAllControls;
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
    public class CertificateControlsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CertificateControlsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CertificateControlsController>
        [HttpGet("{certificateId}")]
        public async Task<IActionResult> GetAll(int certificateId)
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllControlsCommand(certificateId)));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);

            }
        }



        // POST api/<CertificateControlsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CertificateControlsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CertificateControlsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
