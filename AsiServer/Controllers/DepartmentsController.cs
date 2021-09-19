using Asi.Server.Mediator.Departments.Create;
using Asi.Server.Mediator.Departments.Delete;
using Asi.Server.Mediator.Departments.Get;
using Asi.Server.Mediator.Departments.GetAll;
using Asi.Server.Mediator.Departments.Update;
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
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<DepartmentsController>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllDepartmentCommand pagination)
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

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetDepartmentCommand(id)));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDepartmentCommand value)
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

        // PUT api/<DepartmentsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateDepartmentCommand value)
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

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteDepartmentCommand(id));
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
