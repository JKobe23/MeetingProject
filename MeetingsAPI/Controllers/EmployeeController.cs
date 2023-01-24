using MediatR;
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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
