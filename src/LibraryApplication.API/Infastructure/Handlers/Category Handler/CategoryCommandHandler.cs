using Arch.EntityFrameworkCore.UnitOfWork;
using LibraryApplication.API.Infastructure.Commands;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using MediatR;
using Microsoft.VisualStudio.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Handlers
{
    public class CategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = request.category;
            _unitOfWork.GetRepository<Category>().Insert(category);
            _unitOfWork.SaveChanges();
            var task = Task.Run(() => category);
            return await task;
        }
    }
}
