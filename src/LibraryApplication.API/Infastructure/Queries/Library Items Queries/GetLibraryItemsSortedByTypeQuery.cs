using LibraryApplication.API.DTO;
using LibraryApplication.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Queries.Library_Items_Queries
{
    public class GetLibraryItemsSortedByTypeQuery : IRequest<List<LibraryItemDTO>>
    {
    }
}
