using Asi.Application.Mediator.Repositories.Forms.GetItemForm;
using Asi.Application.Mediator.Repositories.Forms.GetMobileForm;
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
    public  class FormController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FormController(IMediator unit)
        {
            _mediator = unit;
        }
        [HttpGet("form/{formid}")]
        public async Task<IActionResult> GetItemForm(int formid)
        {
            try
            {
                return Ok(await _mediator.Send(new GetItemFormCommand(formid)));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
        [HttpGet("mobile/{formid}")]
        
        public async Task<IActionResult> GetMobileForm(int formid)
        {
            try
            {
                return Ok(await _mediator.Send(new GetMobileFormCommand(formid)));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
        //[HttpGet("certform={formid}")]
        //public async Task<IActionResult> GetFormData(int formid)
        //{
        //    try
        //    {
        //        return Ok(await _mediator.Forms.GetFormData(formid));
        //    }
        //    catch (Exception e)
        //    {

        //        return NotFound(e.Message);
        //    }
        //}
        //[HttpPost] 
        //public async Task<IActionResult> CreateForm(ControlFormSendModel controlFormSend)
        //{
        //    try
        //    {
        //       //  controlFormSend = JsonConvert.DeserializeObject<ControlFormSendModel>(System.IO.File.ReadAllText(@"d:\control.txt"));
        //       // System.IO.File.WriteAllText(@"d:\control.txt", JsonConvert.SerializeObject(controlFormSend));
        //        await _mediator.Forms.InsertFormData(   controlFormSend);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {

        //        return NotFound(e.Message);
        //    }
        //}
        //[HttpGet("{formid}")]
        //public IActionResult GetPdf(int formid)
        //{
        //    try
        //    {
        //       // var x = new StiReport();
        //           var v= _mediator.Forms.GetPdf(formid);
        //        return new FileStreamResult(v, "application/pdf");
        //    }
        //    catch (Exception )
        //    {

        //        throw;
        //    }
        //}
    }
}
