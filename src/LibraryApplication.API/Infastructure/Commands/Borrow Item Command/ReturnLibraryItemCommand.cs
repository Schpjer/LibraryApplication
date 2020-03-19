using LibraryApplication.API.DTO;
using LibraryApplication.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Commands.Borrow_Item_Command
{
    public class ReturnLibraryItemCommand : IRequest<BorrowInformationDTO>
    {
        public int Id { set; get; }

        public ReturnLibraryItemCommand(int id)
        {
            Id = id;
        }
    }
}
