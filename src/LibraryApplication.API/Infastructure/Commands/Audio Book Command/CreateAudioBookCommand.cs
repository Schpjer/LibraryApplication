using LibraryApplication.API.DTO;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Commands.Audio_Book_Command
{
    public class CreateAudioBookCommand : IRequest<AudioBookDTO>
    {
        public AudioBook AudioBook { set; get; }

        public CreateAudioBookCommand(AudioBook audioBook)
        {
            AudioBook = audioBook;
        }
    }
}
