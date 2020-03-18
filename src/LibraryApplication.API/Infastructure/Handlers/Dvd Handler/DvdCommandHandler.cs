
using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using LibraryApplication.API.DTO;
using LibraryApplication.API.Infastructure.Commands.Dvd_Command;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Handlers.Dvd_Handler
{
    public class DvdCommandHandler : IRequestHandler<CreateDvdCommand, DvdDTO>,
        IRequestHandler<DeleteDvdCommand, DvdDTO>,
        IRequestHandler<EditDvdCommand, DvdDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DvdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<DvdDTO> Handle(CreateDvdCommand request, CancellationToken cancellationToken)
        {
            var dvd = request.Dvd;
            var category = await _unitOfWork.GetRepository<Category>().FindAsync(dvd.categoryId);
            dvd.Category = category;
            _unitOfWork.GetRepository<Dvd>().Insert(dvd);
            _unitOfWork.SaveChanges();
            // Returns the book that was created in JSON format, if not created Exception will be thrown and middleware will handle it.
            return _mapper.Map<DvdDTO>(dvd);
        }
        public async Task<DvdDTO> Handle(DeleteDvdCommand request, CancellationToken cancellationToken)
        {
            var dvd = await _unitOfWork.GetRepository<Dvd>().FindAsync(request.Id);
            _unitOfWork.GetRepository<Dvd>().Delete(dvd);
            _unitOfWork.SaveChanges();
            return _mapper.Map<DvdDTO>(dvd);
        }
        public async Task<DvdDTO> Handle(EditDvdCommand request, CancellationToken cancellationToken)
        {
            var dvd = request.Dvd;
            var exsistingDvd = await _unitOfWork.GetRepository<Dvd>().FindAsync(dvd.Id);
            var category = await _unitOfWork.GetRepository<Category>().FindAsync(exsistingDvd.categoryId);
            exsistingDvd.Category = category;
            exsistingDvd.RunTimeMinutes = dvd.RunTimeMinutes;
            exsistingDvd.Title = dvd.Title;
            _unitOfWork.GetRepository<Dvd>().Update(exsistingDvd);
            return _mapper.Map<DvdDTO>(exsistingDvd); 
        }
       

    }
}
