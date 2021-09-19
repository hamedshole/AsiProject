using Asi.Server.Mediator.Items.Create;
using Asi.Server.Mediator.Items.Delete;
using Asi.Server.Mediator.Items.Get;
using Asi.Server.Mediator.Items.GetAll;
using Asi.Server.Mediator.Items.Update;
using Asi.Server.Mediator.Repositories.Items.GetServiceTypeItems;
using Asi.Server.Mediator.Repositories.Items.GetUserItems;
using Asi.Server.Mediator.Repositories.Items.GetUserItemsFilterByServiceType;
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
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("servicetype/{servicetypeid}")]
        public async Task<IActionResult> GetServiceTypeItems(int servicetypeid)
        {
            try
            {
                return Ok(await _mediator.Send(new GetServiceTypeItemsCommand(servicetypeid)));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
                throw;
            }
        }
        // GET: api/<ItemsController>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllItemCommand pagination)
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


        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetItemCommand(id)));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        [HttpGet("u={user}")]
        public IActionResult GetUserItems([FromQuery] GetUserItemsCommand pagination)
        {
            try
            {
                return Ok(_mediator.Send(pagination));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
        [HttpGet("users/{userid}/serviceTypes/{serviceType}")]
        public IActionResult GetUserItemsFilterByDepartment(int serviceType, int user)
        {
            try
            {
                return Ok(_mediator.Send(new GetUserItemsFilterByServiceTypeCommand(userId: user, serviceTypeId: serviceType)));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
        // POST api/<ItemsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateItemCommand value)
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

        // PUT api/<ItemsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateItemCommand value)
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

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteItemCommand(id));
                return Ok();
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
    }
}
