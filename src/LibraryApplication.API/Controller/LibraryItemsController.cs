using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApplication.API.Infastructure.Commands.Audio_Book_Command;
using LibraryApplication.API.Infastructure.Commands.Book_Command;
using LibraryApplication.API.Infastructure.Commands.Dvd_Command;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using LibraryApplication.Infastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApplication.API.Controller
{
    [Route("api/libraryItem")]
    public class LibraryItemsController : ControllerBase
    {
        private ILogger<LibraryContext> _logger;
        private IMediator _mediator;

        public LibraryItemsController(IMediator mediator, ILogger<LibraryContext> logger)
        {
            _logger = logger ?? throw new AggregateException(nameof(logger));
            _mediator = mediator ?? throw new AggregateException(nameof(mediator));
        }
        // POST api/libraryItem
        [HttpPost("book")]
        public async Task<IActionResult> CreateBook([FromBody]Book book)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateBookCommand(book);
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        [HttpDelete("book/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var command = new DeleteBookCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("book")]
        public async Task<IActionResult> UpdateAudioBook([FromBody]Book book)
        {
            if (ModelState.IsValid)
            {
                var command = new EditBookCommand(book);
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("audiobook")]
        public async Task<IActionResult> UpdateBook([FromBody]Book book)
        {
            if (ModelState.IsValid)
            {
                var command = new EditBookCommand(book);
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPost("audiobook")]
        public async Task<IActionResult> CreateAudioBook([FromBody]AudioBook audioBook)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateAudioBookCommand(audioBook);
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        [HttpDelete("audiobook/{id}")]
        public async Task<IActionResult> DeleteAudioBook(int id)
        {
            var command = new DeleteAudioBookCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("audiobook")]
        public async Task<IActionResult> UpdateAudioBook([FromBody]AudioBook audioBook)
        {
            if (ModelState.IsValid)
            {
                var command = new EditAudioBookCommand(audioBook);
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        } 
        [HttpPost("dvd")]
        public async Task<IActionResult> CreateDvd([FromBody]Dvd dvd)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateDvdCommand(dvd);
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        [HttpDelete("dvd/{id}")]
        public async Task<IActionResult> DeleteDvd(int id)
        {
            var command = new DeleteDvdCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("dvd")]
        public async Task<IActionResult> UpdateDvd([FromBody]Dvd dvd)
        {
            if (ModelState.IsValid)
            {
                var command = new EditDvdCommand(dvd);
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
