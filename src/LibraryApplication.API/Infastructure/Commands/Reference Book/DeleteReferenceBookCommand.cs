using LibraryApplication.API.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Commands.Reference_Book
{
    public class DeleteReferenceBookCommand : IRequest<ReferenceBookDTO>
    {
        public int Id { set; get; }

        public DeleteReferenceBookCommand(int id)
        {
            Id = id;
        }
    }
}
