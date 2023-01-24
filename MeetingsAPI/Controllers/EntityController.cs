using MediatR;
using MeetingInfrastructure;
using MeetingsMediatR.Queries;
using MeetingsMediatR.Response_Entities;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeetingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<EntityController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<EntityController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            IActionResult result;
            EntityResponse response;
            try
            {
                response = await _mediator.Send(new GetEntityByIdQuery(id));
                result = (response != null) ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                result = NotFound(ex.Message);
            }
            return result;
        }

        // POST api/<EntityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EntityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EntityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
