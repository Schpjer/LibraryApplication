using LibraryApplication.API.DTO;
using LibraryApplication.Domain.AggregateModel.EmployeesAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Commands.Employee_Command
{
    public class CreateEmployeeCommand : IRequest<EmployeeDTO>
    {
        public Employee Employee { set; get; }

        public CreateEmployeeCommand(Employee employee)
        {
            Employee = employee;
        }
    }
}
