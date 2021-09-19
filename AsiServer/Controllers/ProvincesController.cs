using Asi.Server.Mediator.Provinces.Create;
using Asi.Server.Mediator.Provinces.Delete;
using Asi.Server.Mediator.Provinces.Get;
using Asi.Server.Mediator.Provinces.GetAll;
using Asi.Server.Mediator.Provinces.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Asi.Core.Server.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProvincesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CertificateTypesController>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProvinceCommand pagination)
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

        // GET api/<StandardRefferencesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetProvinceCommand(id)));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        // POST api/<StandardRefferencesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProvinceCommand value)
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
        public async Task<IActionResult> Put([FromBody] UpdateProvinceCommand value)
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
                await _mediator.Send(new DeleteProvinceCommand(id));
                return Ok();
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
    }
}
