using Arch.EntityFrameworkCore.UnitOfWork;
using LibraryApplication.API.Infastructure.Commands;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Handlers.Category_Handler
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, Category>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<Category> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = request.category;
            _unitOfWork.GetRepository<Category>().Update(category);
            _unitOfWork.SaveChanges();
            var task = Task.Run(() => category);
            return await task;
        }
    }
}
