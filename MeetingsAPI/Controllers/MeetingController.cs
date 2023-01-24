using MediatR;
using MeetingsMediatR.Queries;
using MeetingsMediatR.Response_Entities;
using Microsoft.AspNetCore.Mvc;

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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MeetingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MeetingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
