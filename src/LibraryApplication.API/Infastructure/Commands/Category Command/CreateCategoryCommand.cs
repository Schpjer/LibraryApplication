using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Commands
{
    public class CreateCategoryCommand: IRequest<Category>
    {
        public Category category { set; get; }

        public CreateCategoryCommand(Category category)
        {
            this.category = category;
        }

    }
}
