using LibraryApplication.API.DTO;
using LibraryApplication.Domain.AggregateModel.EmployeesAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Commands.Employee_Command
{
    public class DeleteEmployeeCommand : IRequest<EmployeeDTO>
    {
        public int Id { set; get; }

        public DeleteEmployeeCommand(int id)
        {
            Id = id;
        }
    }
}
