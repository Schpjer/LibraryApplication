using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using LibraryApplication.API.DTO;
using LibraryApplication.API.Infastructure.Commands.Reference_Book;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Handlers.Reference_Book_Handler
{
    public class ReferenceBookHandler : IRequestHandler<CreateReferenceBookCommand, ReferenceBookDTO>,
        IRequestHandler<DeleteReferenceBookCommand, ReferenceBookDTO>,
        IRequestHandler<EditReferenceBookCommand, ReferenceBookDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReferenceBookHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ReferenceBookDTO> Handle(CreateReferenceBookCommand request, CancellationToken cancellationToken)
        {
            var referenceBook = request.ReferenceBook;
            var category = await _unitOfWork.GetRepository<Category>().FindAsync(referenceBook.categoryId);
            _unitOfWork.GetRepository<ReferenceBook>().Insert(referenceBook);
            _unitOfWork.SaveChanges();
            // Returns the book that was created in JSON format, if not created Exception will be thrown and middleware will handle it.
            return _mapper.Map<ReferenceBookDTO>(referenceBook);
        }

        public async Task<ReferenceBookDTO> Handle(DeleteReferenceBookCommand request, CancellationToken cancellationToken)
        {
            var referenceBook = await _unitOfWork.GetRepository<ReferenceBook>().FindAsync(request.Id);
            var category = await _unitOfWork.GetRepository<Category>().FindAsync(referenceBook.categoryId);
            referenceBook.Category = category;
            _unitOfWork.GetRepository<ReferenceBook>().Delete(referenceBook);
            _unitOfWork.SaveChanges();
            return _mapper.Map<ReferenceBookDTO>(referenceBook);
        }

        public async Task<ReferenceBookDTO> Handle(EditReferenceBookCommand request, CancellationToken cancellationToken)
        {
          
            var bookUpdate = request.ReferenceBook;
            var existingReferenceBook = await _unitOfWork.GetRepository<ReferenceBook>().FindAsync(bookUpdate.Id);
            var category = _unitOfWork.GetRepository<Category>().Find(existingReferenceBook.categoryId);
            existingReferenceBook.Category = category;
            existingReferenceBook.Pages = bookUpdate.Pages;
            existingReferenceBook.Author = bookUpdate.Author;
            existingReferenceBook.Title = bookUpdate.Title;
            _unitOfWork.GetRepository<ReferenceBook>().Update(existingReferenceBook);
            _unitOfWork.SaveChanges();
            return _mapper.Map<ReferenceBookDTO>(existingReferenceBook);
        }
    }
}
