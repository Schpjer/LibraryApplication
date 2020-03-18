using LibraryApplication.API.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Commands.Book_Command
{
    public class DeleteBookCommand: IRequest<BookDTO>
    {
        public int Id { set; get; }

        public DeleteBookCommand(int id)
        {
            Id = id;
        }
    }
}
