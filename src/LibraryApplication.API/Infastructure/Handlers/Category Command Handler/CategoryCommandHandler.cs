using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using LibraryApplication.API.DTO;
using LibraryApplication.API.Infastructure.Commands;
using LibraryApplication.API.Infastructure.Commands.Category_Command;
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
    public class CategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDTO>,
        IRequestHandler<DeleteCategoryCommand, CategoryDTO>,
        IRequestHandler<EditCategoryCommand, CategoryDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<CategoryDTO> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = request.Category;
            _unitOfWork.GetRepository<Category>().Insert(category);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CategoryDTO>(category);
           
        }
        public async Task<CategoryDTO> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.GetRepository<Category>().FindAsync(request.Id);
            _unitOfWork.GetRepository<Category>().Delete(category);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CategoryDTO>(category);
        }
        public async Task<CategoryDTO> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            //Updates category in the database when you change the category name.
            var category = request.Category;
            _unitOfWork.GetRepository<Category>().Update(category);
            await _unitOfWork.SaveChangesAsync();
            return  _mapper.Map<CategoryDTO>(category);
        }
    }
}
