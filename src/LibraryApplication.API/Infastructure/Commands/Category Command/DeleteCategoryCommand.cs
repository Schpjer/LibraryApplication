using LibraryApplication.API.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Commands.Category_Command
{
    public class DeleteCategoryCommand : IRequest<CategoryDTO>
    {
        public int Id { set; get; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
