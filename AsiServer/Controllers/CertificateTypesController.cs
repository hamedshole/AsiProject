using Asi.Server.Mediator.CertificateTypes.CreateCertificateType;
using Asi.Server.Mediator.CertificateTypes.DeleteCertificateType;
using Asi.Server.Mediator.CertificateTypes.GetAllCertificateType;
using Asi.Server.Mediator.CertificateTypes.GetCertificateType;
using Asi.Server.Mediator.CertificateTypes.UpdateCertificateType;
using Asi.Server;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asi.Core.Server.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CertificateTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CertificateTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CertificateTypesController>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter pagination)
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllCertificateTypesCommand()));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }


        // GET api/<StandardRefferencesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetCertificateTypeCommand(id)));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        // POST api/<StandardRefferencesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCertificateTypeCommand value)
        {
            try
            {
                await _mediator.Send(value);
                return Ok();
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        // PUT api/<StandardRefferencesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateCertificateTypeCommand value)
        {
            try
            {
                await _mediator.Send(value);
                return Ok();
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        // DELETE api/<StandardRefferencesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteCertificateTypeCommand(id));
                return Ok();
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
    }
}
