using LibraryApplication.API.DTO;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Commands.Reference_Book
{
    public class EditReferenceBookCommand : IRequest<ReferenceBookDTO>
    {
        public ReferenceBook ReferenceBook { set; get; }

        public EditReferenceBookCommand(ReferenceBook referenceBook)
        {
            ReferenceBook = referenceBook;
        }
    }
}
