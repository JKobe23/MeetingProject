using MediatR;
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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PositionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PositionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
