using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using LibraryApplication.API.DTO;
using LibraryApplication.API.Infastructure.Commands.Book_Command;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Handlers
{
    public class BookCommandHandler : IRequestHandler<CreateBookCommand, BookDTO>,
        IRequestHandler<DeleteBookCommand, BookDTO>,
        IRequestHandler<EditBookCommand, BookDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private  readonly IMapper _mapper;
        

        public BookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<BookDTO> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = request.Book;
            var category = _unitOfWork.GetRepository<Category>().Find(book.categoryId);
            _unitOfWork.GetRepository<Book>().Insert(book);
            _unitOfWork.SaveChanges();
            // Returns the book that was created in JSON format, if not created Exception will be thrown and middleware will handle it.
            return _mapper.Map<BookDTO>(book);
        }
        public async Task<BookDTO> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = _unitOfWork.GetRepository<Book>().Find(request.Id);
            var category = _unitOfWork.GetRepository<Category>().Find(book.categoryId);
            _unitOfWork.GetRepository<Book>().Delete(book);
            _unitOfWork.SaveChanges();
            return _mapper.Map<BookDTO>(book);
        }
        public async Task<BookDTO> Handle(EditBookCommand request, CancellationToken cancellationToken)
        {
            // BookUpdate represents the book with updateded values
            var bookUpdate = request.Book;
            // ExisitingBook is a book that is already in the database
            var exsistingBook = await _unitOfWork.GetRepository<Book>().FindAsync(bookUpdate.Id);
            var category = _unitOfWork.GetRepository<Category>().Find(exsistingBook.categoryId);
            exsistingBook.Category = category;
            exsistingBook.Pages = bookUpdate.Pages;
            exsistingBook.Author = bookUpdate.Author;
            exsistingBook.Title = bookUpdate.Title;
            _unitOfWork.GetRepository<Book>().Update(exsistingBook);
            _unitOfWork.SaveChanges();
            return _mapper.Map<BookDTO>(exsistingBook);

        }
    }
}
