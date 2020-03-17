using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApplication.API.Infastructure.Commands;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using LibraryApplication.Infastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApplication.API.Controller
{
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private ILogger<LibraryContext> _logger;
        private IMediator _mediator;

        public CategoryController(IMediator mediator, ILogger<LibraryContext> logger)
        {
            _logger = logger ?? throw new AggregateException(nameof(logger));
            _mediator = mediator ?? throw new AggregateException(nameof(mediator));
        }
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]Category category)
        {
            var command = new CreateCategoryCommand(category);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody]Category category)
        {
            var command = new EditCategoryCommand(category);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
