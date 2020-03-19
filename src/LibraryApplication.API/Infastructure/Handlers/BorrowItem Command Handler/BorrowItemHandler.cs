using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using LibraryApplication.API.DTO;
using LibraryApplication.API.Infastructure.Commands.Book_Command;
using LibraryApplication.API.Infastructure.Commands.Borrow_Item_Command;
using LibraryApplication.Domain;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Handlers.BorrowItemHandler
{
    public class BorrowItemHandler : IRequestHandler<BorrowLibraryItemCommand, BorrowInformationDTO>,
        IRequestHandler<ReturnLibraryItemCommand, BorrowInformationDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BorrowItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BorrowInformationDTO> Handle(BorrowLibraryItemCommand request, CancellationToken cancellationToken)
        {
            var borrowInformationItem = request.BorrowItem;
            var libraryItem = await _unitOfWork.GetRepository<LibraryItem>().FindAsync(borrowInformationItem.Id);
            if (libraryItem.IsBorrowable)
            {
                libraryItem.Borrower = borrowInformationItem.Borrower;
                libraryItem.BorrowDate = borrowInformationItem.BorrowDate;
                libraryItem.IsBorrowable = false;
                _unitOfWork.GetRepository<LibraryItem>().Update(libraryItem);
                await _unitOfWork.SaveChangesAsync();
                var borrowSucessItemDTO =_mapper.Map<BorrowInformationDTO>(libraryItem);
                borrowSucessItemDTO.BorrowMessage = "Item borrowed";
                return borrowSucessItemDTO;
            } else if (!libraryItem.IsBorrowable && libraryItem.Type != nameof(ReferenceBook))
            {
                var borrowUnsucessfulItemDTO = _mapper.Map<BorrowInformationDTO>(libraryItem);
                borrowUnsucessfulItemDTO.BorrowMessage = "Item is already borrowed";
                return borrowUnsucessfulItemDTO;
            } else
            {
                var borrowUnsucessfulItemDTO = _mapper.Map<BorrowInformationDTO>(libraryItem);
                borrowUnsucessfulItemDTO.BorrowMessage = "Unable to borrow Reference Book";
                return borrowUnsucessfulItemDTO;
            }

        }

        public async Task<BorrowInformationDTO> Handle(ReturnLibraryItemCommand request, CancellationToken cancellationToken)
        {
            var libraryItem = await _unitOfWork.GetRepository<LibraryItem>().FindAsync(request.Id);
            if (!libraryItem.IsBorrowable && libraryItem.Type != nameof(ReferenceBook))
            {
                libraryItem.IsBorrowable = true;
                libraryItem.BorrowDate = DateTime.MinValue;
                libraryItem.Borrower = null;
                _unitOfWork.GetRepository<LibraryItem>().Update(libraryItem);
                _unitOfWork.SaveChanges();
                var returnedLibraryItem = _mapper.Map<BorrowInformationDTO>(libraryItem);
                returnedLibraryItem.BorrowMessage = "Item successfully returned";
                return returnedLibraryItem;
            } else if (libraryItem.Type == nameof(ReferenceBook))
            {
                var returnedLibraryItem = _mapper.Map<BorrowInformationDTO>(libraryItem);
                returnedLibraryItem.BorrowMessage = "Reference book can't be returned";
                return returnedLibraryItem;
            }else
            {
                var returnedLibraryItem = _mapper.Map<BorrowInformationDTO>(libraryItem);
                returnedLibraryItem.BorrowMessage = "Item is not borrowed";
                return returnedLibraryItem;

            }
        }
    }
}
