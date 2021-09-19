using Asi.Server.Mediator.Users.Create;
using Asi.Server.Mediator.Users.Delete;
using Asi.Server.Mediator.Users.Get;
using Asi.Server.Mediator.Users.GetAll;
using Asi.Server.Mediator.Users.Update;
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
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUserCommand pagination)
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

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetUserCommand(id)));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand value)
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

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand value)
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

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteUserCommand(id));
                return Ok();
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
    }
}
