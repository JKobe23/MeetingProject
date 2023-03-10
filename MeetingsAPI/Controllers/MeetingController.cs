using MediatR;
using MeetingsMediatR.Commands.Create;
using MeetingsMediatR.Commands.Delete;
using MeetingsMediatR.Queries;
using MeetingsMediatR.Response_Entities;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeetingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MeetingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<MeetingController>
        [HttpGet]
        public async Task<IEnumerable<MeetingResponse>> Get()
        {
            IEnumerable<MeetingResponse> meetings = new List<MeetingResponse>();
            try
            {
                meetings = await _mediator.Send(new GetMeetingsListQuery());
            }
            catch (Exception ex)
            {
                meetings = Enumerable.Empty<MeetingResponse>();
            }
            return meetings;
        }

        // GET api/<MeetingController>/5
        [HttpGet("{refnum}")]
        public async Task<IActionResult> Get(string refnum)
        {
            IActionResult result;
            MeetingResponse response;
            try
            {
                response = await _mediator.Send(new GetMeetingByRefQuery(refnum));
                result = (response != null) ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                result = NotFound(ex.Message);
            }
            return result;
        }

        // POST api/<MeetingController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMeetingCommand command)
        {
            IActionResult result;
            try
            {
                MeetingResponse meeting = await _mediator.Send(command);

                if (meeting == null)
                {
                    result = BadRequest();
                }
                else
                {
                    result = Created("Meetings", meeting.ID);
                }
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }
            return result;
        }

        // PUT api/<MeetingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MeetingController>/5
        [HttpDelete("{refnum}")]
        public async Task<IActionResult> Delete(string refnum)
        {
            IActionResult result;
            try
            {
                MeetingResponse response = await _mediator.Send(new DeleteMeetingCommand(refnum));
                result = NoContent();
                if (response == null)
                {
                    result = NotFound();
                }
            }
            catch (Exception ex)
            {
                result = NotFound(ex.Message);
            }

            return result;
        }
    }
}
