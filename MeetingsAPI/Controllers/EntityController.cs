using MediatR;
using MeetingCore;
using MeetingInfrastructure;
using MeetingsMediatR.Commands.Create;
using MeetingsMediatR.Commands.Delete;
using MeetingsMediatR.Commands.Update;
using MeetingsMediatR.Queries;
using MeetingsMediatR.Response_Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        public async Task<IActionResult> Post([FromBody] CreateEntityCommand command)
        {
            IActionResult result;
            try
            {
                EntityResponse entity = await _mediator.Send(command);
                result = Created("Positions", entity.ID);
            }
            catch (Exception ex)
            {
                result = Conflict(ex.Message);
            }
            return result;
        }

        // PUT api/<EntityController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateEntityCommand command)
        {
            IActionResult result;
            try
            {
                EntityResponse entity = await _mediator.Send(command);
                if (entity ==null)
                {
                    result= NotFound();
                }
                else
                {
                    result = Ok(entity);
                }

            }
            catch (Exception ex)
            {
                result = new JsonResult(ex.Message);
            }

            return result;
        }

        // DELETE api/<EntityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            IActionResult result;
            try
            {
                EntityResponse response = await _mediator.Send(new DeleteEntityCommand(id));
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
