using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using LibraryApplication.API.DTO;
using LibraryApplication.API.Infastructure.Commands.Employee_Command;
using LibraryApplication.Domain.AggregateModel.EmployeesAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryApplication.API.Infastructure.Handlers.Employee_Command_Handler
{
    public class EmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDTO>,
        IRequestHandler<DeleteEmployeeCommand, EmployeeDTO>,
        IRequestHandler<EditEmployeeCommand, EmployeeDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EmployeeDTO> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = request.Employee;
            //Checks if we are trying to create CEO
            if (employee.IsCEO)
            {
                // Makes Sure that there is no CEO already in the database
                var checkIfCEOExist = _unitOfWork.GetRepository<Employee>().GetAll().Where(t => t.IsCEO == true).FirstOrDefault();
                //Makes sure that we are not trying to set ManagerId to CEO when he/she cant be managed and that our search for CEO returned NULL
                if (checkIfCEOExist == null && employee.ManagerId == 0)
                {
                    employee.SetSalary(employee.SalaryCoefficient);
                    _unitOfWork.GetRepository<Employee>().Insert(employee);
                    _unitOfWork.SaveChanges();
                    return _mapper.Map<EmployeeDTO>(employee);
                }
                // Checks if we are trying to create create a Manager
            }
            else if (employee.IsManager)
            {
                var checkIfManagerExist = _unitOfWork.GetRepository<Employee>().GetAll().Where(t => t.Id == employee.ManagerId).First();
                //Checks that the manager we are trying to set to the manager either is a manager or CEO
                if (checkIfManagerExist.IsManager || checkIfManagerExist.IsCEO)
                {
                    employee.SetSalary(employee.SalaryCoefficient);
                    _unitOfWork.GetRepository<Employee>().Insert(employee);
                    _unitOfWork.SaveChanges();
                    return _mapper.Map<EmployeeDTO>(employee);
                }
            }
            else
            {
                // If we are not trying to create CEO or Manager it automatically tries to create employee
                var checkIfManagerExist = _unitOfWork.GetRepository<Employee>().GetAll().Where(t => t.Id == employee.ManagerId).First();
                //Makes sure that manager exist and that its not the CEO we are trying to set as manager for Employee
                if (checkIfManagerExist != null && checkIfManagerExist.IsManager && !checkIfManagerExist.IsCEO)
                {
                    employee.SetSalary(employee.SalaryCoefficient);
                    _unitOfWork.GetRepository<Employee>().Insert(employee);
                    _unitOfWork.SaveChanges();
                    return _mapper.Map<EmployeeDTO>(employee);
                }
            }

            return null;

        }

        public async Task<EmployeeDTO> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.GetRepository<Employee>().FindAsync(request.Id);
            //Checks if we are trying to delete manager or CEO
            if (employee.IsManager || employee.IsCEO)
            {
                // Gets a list of employees that the CEO/Manager is managing 
                var managedList = _unitOfWork.GetRepository<Employee>().GetAll().Where(t => t.ManagerId == employee.Id);
                //If the manager/ceo isn't managing any employees/manager employee will be deleted from table
                if (!managedList.Any())
                {
                    _unitOfWork.GetRepository<Employee>().Delete(employee);
                    await _unitOfWork.SaveChangesAsync();
                    return _mapper.Map<EmployeeDTO>(employee);
                }

            } // if none of the following conditons are true it will delete the employee
            else
            {
                _unitOfWork.GetRepository<Employee>().Delete(employee);
                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<EmployeeDTO>(employee);
            }
            return null;
        }

        public async Task<EmployeeDTO> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = request.Employee;
            var exsistingEmployee = await _unitOfWork.GetRepository<Employee>().FindAsync(employee.Id);
            exsistingEmployee.FirstName = employee.FirstName;
            exsistingEmployee.LastName = employee.LastName;
            exsistingEmployee.SalaryCoefficient = employee.SalaryCoefficient;
            exsistingEmployee.SetSalary(exsistingEmployee.SalaryCoefficient);
            _unitOfWork.GetRepository<Employee>().Update(exsistingEmployee);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<EmployeeDTO>(exsistingEmployee);
                
            
        }
    }
}
