using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using LibraryApplication.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Queries.Library_Items_Queries
{
    public class GetLibraryItemsSortedByCategoryQuery : IRequest<List<LibraryItem>>
    {  
   
    }
}
