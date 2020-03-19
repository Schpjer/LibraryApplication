using AutoMapper;
using LibraryApplication.API.DTO;
using LibraryApplication.Domain;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            // this maps so we can convert our different models to the DTOS and information we want to send back to the user.
            CreateMap<Domain.AggregateModel.LibrayAggregate.Book, BookDTO>()
                .ConstructUsing(src => new BookDTO(src.Title, src.Pages, src.Author, src.Category.CategoryName));
            CreateMap<ReferenceBook, ReferenceBookDTO>()
                .ConstructUsing(src => new ReferenceBookDTO(src.Title,  src.Author, src.Pages, src.Category.CategoryName));
            CreateMap<Category, CategoryDTO>();
            CreateMap<Dvd, DvdDTO>()
                .ConstructUsing(src => new DvdDTO(src.Title, src.RunTimeMinutes, src.Category.CategoryName));
            CreateMap<AudioBook, AudioBookDTO>()
                .ConstructUsing(src => new AudioBookDTO(src.Title, src.RunTimeMinutes, src.Category.CategoryName));
            CreateMap<LibraryItem, BorrowInformationDTO>()
                .ConstructUsing(src => new BorrowInformationDTO(src.Title, src.BorrowDate, src.Borrower));


        }
    }
}
