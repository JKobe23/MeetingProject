using MediatR;
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
        public async Task<IActionResult> Post([FromBody] CreateSubjectCommand command)
        {
            IActionResult result;
            try
            {
                SubjectResponse subject = await _mediator.Send(command);

                if (subject == null)
                {
                    result = BadRequest();
                }
                else
                {
                    result = Created("Subjects", subject.ID);
                }
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }
            return result;
        }

        // PUT api/<SubjectController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateSubjectCommand command)
        {
            IActionResult result;
            try
            {
                SubjectResponse subject = await _mediator.Send(command);
                if (subject == null)
                {
                    result = NotFound();
                }
                else
                {
                    result = Ok(subject);
                }

            }
            catch (Exception ex)
            {
                result = new JsonResult(ex.Message);
            }

            return result;
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{refnum}")]
        public async Task<IActionResult> Delete(string refnum)
        {
            IActionResult result;
            try
            {
                SubjectResponse response = await _mediator.Send(new DeleteSubjectCommand(refnum));
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
