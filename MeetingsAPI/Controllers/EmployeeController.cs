using MediatR;
using MeetingsMediatR.Commands.Create;
using MeetingsMediatR.Commands.Delete;
using MeetingsMediatR.Commands.Update;
using MeetingsMediatR.Queries;
using MeetingsMediatR.Response_Entities;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeetingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IEnumerable<EmployeeResponse>> Get()
        {
            IEnumerable<EmployeeResponse> employees = new List<EmployeeResponse>();  
            try {
                employees = await _mediator.Send(new GetEmployeesListQuery());

            } catch (Exception ex)
            {
                employees = Enumerable.Empty<EmployeeResponse>(); 
            }
            return employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{ssn}")]
        public async Task<IActionResult> Get(string ssn)
        {
            IActionResult result;
            EmployeeResponse response;
            try
            {
                response = await _mediator.Send(new GetEmployeeBySsnQuery(ssn));
                result = (response != null) ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                result = NotFound(ex.Message);
            }
            return result;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeCommand command)
        {
            IActionResult result;
            try
            {
                EmployeeResponse employee = await _mediator.Send(command);
                
                if(employee == null)
                {
                    result = BadRequest();
                }
                else
                {
                    result = Created("Positions", employee.ID);
                }
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }
            return result;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateEmployeeCommand command)
        {
            IActionResult result;
            try
            {
                EmployeeResponse employee = await _mediator.Send(command);
                if (employee == null)
                {
                    result = NotFound();
                }
                else
                {
                    result = Ok(employee);
                }

            }
            catch (Exception ex)
            {
                result = new JsonResult(ex.Message);
            }

            return result;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{ssn}")]
        public async Task<IActionResult> Delete(string ssn)
        {
            IActionResult result;
            try
            {
                EmployeeResponse response = await _mediator.Send(new DeleteEmployeeCommand(ssn));
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
