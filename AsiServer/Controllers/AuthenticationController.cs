using Asi.Server.Mediator.Repositories.Authentication.AddUserSigniture;
using Asi.Server.Mediator.Repositories.Authentication.Login;
using Asi.Server.Mediator.Repositories.Authentication.Register;
using Asi.Model;
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
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand loginCommand)
        {
            try
            {
               
                return Ok(await _mediator.Send(loginCommand));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
        [HttpPost("register")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> Register(RegisterCommand loginCommand)
        {
            try
            {
                await _mediator.Send(loginCommand);
                return Ok();
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        [HttpPost("updateusersigniture")]
        public async Task<IActionResult> UpdatePersonSigniture([FromBody]UserModel user)
        {
            try
            {
                await _mediator.Send(new AddUserSignitureCommand(user.PersonId, user.Signiture));
                return Ok();
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
    }
}
