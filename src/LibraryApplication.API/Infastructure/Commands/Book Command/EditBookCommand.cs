using LibraryApplication.API.DTO;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Commands.Book_Command
{
    public class EditBookCommand : IRequest<BookDTO>
    {
        public Book Book { set; get; }

        public EditBookCommand(Book book)
        {
            Book = book;
        }
    }
}
