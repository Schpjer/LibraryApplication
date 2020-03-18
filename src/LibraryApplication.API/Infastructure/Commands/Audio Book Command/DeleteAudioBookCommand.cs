using LibraryApplication.API.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Commands.Audio_Book_Command
{
    public class DeleteAudioBookCommand : IRequest<AudioBookDTO>
    {
        public int Id { set; get; }

        public DeleteAudioBookCommand(int id)
        {
            Id = id;
        }
    }
}
