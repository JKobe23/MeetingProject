using MediatR;
using MeetingsMediatR.Queries;
using MeetingsMediatR.Response_Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeetingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubjectController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<SubjectController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<SubjectController>/5
        [HttpGet("{refnum}")]
        public async Task<IActionResult> Get(string refnum)
        {
            IActionResult result;
            SubjectResponse response;
            try
            {
                response = await _mediator.Send(new GetSubjectByRefQuery(refnum));
                result = (response != null) ? Ok(response) : NotFound();
            } catch (Exception ex)
            {
                result = NotFound(ex.Message);
            } 
            return result;   
        }

        // POST api/<SubjectController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
