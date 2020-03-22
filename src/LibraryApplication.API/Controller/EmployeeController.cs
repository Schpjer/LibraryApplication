using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using LibraryApplication.API.Infastructure.Commands.Employee_Command;
using LibraryApplication.API.Infastructure.Queries.Employee_Queries;
using LibraryApplication.Domain.AggregateModel.EmployeesAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.API.Controller
{

    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new AggregateException(nameof(mediator));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var command = new GetEmployeesQuery();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateEmployeeCommand(employee);
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var command = new EditEmployeeCommand(employee);
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        // DELETE api/Employee/5
        // DELETE employee with Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var command = new DeleteEmployeeCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 
