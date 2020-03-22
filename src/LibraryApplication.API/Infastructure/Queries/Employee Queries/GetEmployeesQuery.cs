using LibraryApplication.API.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Queries.Employee_Queries
{
    public class GetEmployeesQuery : IRequest<List<EmployeeDTO>>
    {

    }
}
