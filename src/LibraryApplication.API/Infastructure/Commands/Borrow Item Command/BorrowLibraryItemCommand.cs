using LibraryApplication.API.DTO;
using LibraryApplication.Domain;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Commands.Book_Command
{
    public class BorrowLibraryItemCommand : IRequest<BorrowInformationDTO>
    {
        public LibraryItem BorrowItem { set; get; }

        public BorrowLibraryItemCommand(LibraryItem borrowItem)
        {
            BorrowItem = borrowItem;
        }
    }
}
