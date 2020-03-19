using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using LibraryApplication.API.DTO;
using LibraryApplication.API.Infastructure.Commands.Audio_Book_Command;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Handlers.Audio_Book_Handler
{
    public class AudioBookHandler : IRequestHandler<CreateAudioBookCommand, AudioBookDTO>,
        IRequestHandler<DeleteAudioBookCommand, AudioBookDTO>,
        IRequestHandler<EditAudioBookCommand, AudioBookDTO>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AudioBookHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AudioBookDTO> Handle(CreateAudioBookCommand request, CancellationToken cancellationToken)
        {
            var audioBook = request.AudioBook;
            var category = await _unitOfWork.GetRepository<Category>().FindAsync(audioBook.categoryId);
            audioBook.Category = category;
            _unitOfWork.GetRepository<AudioBook>().Insert(audioBook);
            _unitOfWork.SaveChanges();
            return _mapper.Map<AudioBookDTO>(audioBook);
        }

        public async Task<AudioBookDTO> Handle(DeleteAudioBookCommand request, CancellationToken cancellationToken)
        {
            var audioBook = await _unitOfWork.GetRepository<AudioBook>().FindAsync(request.Id);
            _unitOfWork.GetRepository<AudioBook>().Delete(audioBook);
            _unitOfWork.SaveChanges();
            return _mapper.Map<AudioBookDTO>(audioBook);
        }

        public async Task<AudioBookDTO> Handle(EditAudioBookCommand request, CancellationToken cancellationToken)
        {
            var audioBook = request.AudioBook;
            var exsistingAudioBook = await _unitOfWork.GetRepository<AudioBook>().FindAsync(audioBook.Id);
            exsistingAudioBook.RunTimeMinutes = audioBook.RunTimeMinutes;
            exsistingAudioBook.Title = audioBook.Title;
            _unitOfWork.GetRepository<AudioBook>().Update(exsistingAudioBook);
            return _mapper.Map<AudioBookDTO>(exsistingAudioBook);
        }
    }
}
