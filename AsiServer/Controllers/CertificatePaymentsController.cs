using Asi.Server.Mediator.CertificatePayments.GetAllPayments;
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
    public class CertificatePaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CertificatePaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PaymentsController>
        [HttpGet("{certid}")]
        public async Task<IActionResult> GetAll(int certid)
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllPaymentsCommand(certid)));
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        // POST api/<PaymentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PaymentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PaymentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
