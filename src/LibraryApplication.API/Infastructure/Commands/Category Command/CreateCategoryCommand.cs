using LibraryApplication.API.DTO;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Commands
{
    public class CreateCategoryCommand: IRequest<CategoryDTO>
    {
        public Category Category { set; get; }

        public CreateCategoryCommand(Category category)
        {
            Category = category;
        }

    }
}
