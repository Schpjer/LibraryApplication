using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApplication.API.Infastructure.Commands;
using LibraryApplication.API.Infastructure.Commands.Category_Command;
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
     
        // POST api/category
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]Category category)
        {
            var command = new CreateCategoryCommand(category);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT api/category
        [HttpPut]
        public async Task<IActionResult> PutCategory([FromBody]Category category)
        {
            var command = new EditCategoryCommand(category);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // DELETE api/category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var command = new DeleteCategoryCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
       
    }
}
