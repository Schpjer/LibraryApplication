using LibraryApplication.API.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Commands.Dvd_Command
{
    public class DeleteDvdCommand : IRequest<DvdDTO>
    {
        public int Id { set; get; }

        public DeleteDvdCommand(int id)
        {
            Id = id;
        }
    }
}
