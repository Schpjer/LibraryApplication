using LibraryApplication.API.DTO;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Commands.Dvd_Command
{
    public class EditDvdCommand : IRequest<DvdDTO>
    {
        public Dvd Dvd { set; get; }

        public EditDvdCommand(Dvd dvd)
        {
            Dvd = dvd;
        }
    }
}
