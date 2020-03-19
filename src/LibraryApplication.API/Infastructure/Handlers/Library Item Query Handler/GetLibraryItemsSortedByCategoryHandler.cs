using Arch.EntityFrameworkCore.UnitOfWork;
using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using AutoMapper;
using LibraryApplication.API.Infastructure.Queries.Library_Items_Queries;
using LibraryApplication.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Handlers.Library_Item_Query_Handler
{
    public class GetLibraryItemsSortedByCategoryHandler : IRequestHandler<GetLibraryItemsSortedByCategoryQuery, List<LibraryItem>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLibraryItemsSortedByCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<LibraryItem>> Handle(GetLibraryItemsSortedByCategoryQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _unitOfWork.GetRepository<LibraryItem>().GetAll().OrderBy(t => t.Category.CategoryName).ToList());
        }
    }
}
