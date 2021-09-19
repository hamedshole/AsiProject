using Asi.Server.Mediator.Repositories.ServiceTypes.GetDepartmentServiceTypes;
using Asi.Server.Mediator.ServiceTypes.Create;
using Asi.Server.Mediator.ServiceTypes.Delete;
using Asi.Server.Mediator.ServiceTypes.Get;
using Asi.Server.Mediator.ServiceTypes.GetAll;
using Asi.Server.Mediator.ServiceTypes.Update;
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
    public class ServiceTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("department/{departmentid}")]
        public async Task<IActionResult> GetDepartmentServiceTypes(int departmentid)
        {
            try
            {

                return Ok(await _mediator.Send(new GetDepartmeentServiceTypesCommand(departmentid)));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
        // GET: api/<ServiceTypeController>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllServiceTypeCommand pagination)
        {
            try
            {
                var d = await _mediator.Send(pagination);
                return Ok(d);
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        // GET api/<ServiceTypeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetServiceTypeCommand(id)));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);

            }
        }

        // POST api/<ServiceTypeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateServiceTypeCommand value)
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

        // PUT api/<ServiceTypeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateServiceTypeCommand value)
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

        // DELETE api/<ServiceTypeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteServiceTypeCommand(id));
                return Ok();
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
    }
}
