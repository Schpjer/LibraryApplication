using LibraryApplication.API.DTO;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Commands.Audio_Book_Command
{
    public class EditAudioBookCommand : IRequest<AudioBookDTO>
    {
        public AudioBook AudioBook { set; get; }

        public EditAudioBookCommand(AudioBook audioBook)
        {
            AudioBook = audioBook;
        }
    }
}
