using AutoMapper;
using LibraryApplication.API.DTO;
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
            CreateMap<Book, BookDTO>()
                .ConstructUsing(src => new BookDTO(src.Title, src.Pages, src.Author, src.Category.CategoryName));
            CreateMap<Category, CategoryDTO>();
            CreateMap<Dvd, DvdDTO>()
                .ConstructUsing(src => new DvdDTO(src.Title, src.RunTimeMinutes, src.Category.CategoryName));
            CreateMap<AudioBook, AudioBookDTO>()
                .ConstructUsing(src => new AudioBookDTO(src.Title, src.RunTimeMinutes, src.Category.CategoryName));


        }
    }
}
