using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using LibraryApplication.API.DTO;
using LibraryApplication.API.Infastructure.Queries.Library_Items_Queries;
using LibraryApplication.Domain;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Handlers.Library_Item_Query_Handler
{
    public class GetLibraryItemsSortedByTypeHandler : IRequestHandler<GetLibraryItemsSortedByTypeQuery, List<LibraryItemDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLibraryItemsSortedByTypeHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<LibraryItemDTO>> Handle(GetLibraryItemsSortedByTypeQuery request, CancellationToken cancellationToken)
        {
            List<LibraryItem> list = _unitOfWork.GetRepository<LibraryItem>().GetAll().OrderBy(t => t.Type).ToList();
            List<LibraryItemDTO> listDTO = new List<LibraryItemDTO>();
            foreach(LibraryItem item in list)
            {
                var category = _unitOfWork.GetRepository<Category>().Find(item.categoryId);
                item.Category = category;
                var itemDTO = _mapper.Map<LibraryItemDTO>(item);
                listDTO.Add(itemDTO);
            }
            return listDTO;
        }
    }
}
