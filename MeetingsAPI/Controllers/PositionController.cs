using MediatR;
using MeetingCore;
using MeetingsMediatR.Commands.Create;
using MeetingsMediatR.Commands.Delete;
using MeetingsMediatR.Commands.Update;
using MeetingsMediatR.Queries;
using MeetingsMediatR.Response_Entities;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeetingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PositionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<PositionController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<PositionController>/5

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            IActionResult result;
            PositionResponse response;
            try
            {
                response = await _mediator.Send(new GetPositionByIdQuery(id));
                result = (response != null) ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                result = NotFound(ex.Message);
            }
            return result;
        }

        // POST api/<PositionController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePositionCommand command)
        {
            IActionResult result;
            try
            {
                PositionResponse position = await _mediator.Send(command);
                result = Created("Positions", position.ID);
            } catch(Exception ex)
            {
                result = Conflict(ex.Message);
            }
            return result;
        }

        // PUT api/<PositionController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePositionCommand command)
        {
            IActionResult result;
            try
            {
                PositionResponse position = await _mediator.Send(command);
                if (position == null)
                {
                    result = NotFound();
                }
                else
                {
                    result = Ok(position);
                }

            }
            catch (Exception ex)
            {
                result = new JsonResult(ex.Message);
            }

            return result;
        }

        // DELETE api/<PositionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            IActionResult result;
            try
            {
                PositionResponse response = await _mediator.Send(new DeletePositionCommand(id));
                result = NoContent();
                if (response == null)
                {
                    result = NotFound();
                }
            } catch(Exception ex)
            {
                result = NotFound(ex.Message);
            }
            
            return result;
        }
    }
}
