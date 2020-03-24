using LibraryApplication.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryApplication.Domain.AggregateModel.EmployeesAggregate
{
    public class Employee: Entity
    {
        [Required(ErrorMessage = "First name is requried")]
        public string FirstName { set; get; }
        [Required(ErrorMessage = "Last name is requried")]
        public string LastName { set; get; }
        public double Salary { set; get; }
        public bool IsCEO { set; get; }
        public bool IsManager { set; get; }
        public int ManagerId { set; get; }

        [NotMapped]
        [Required(ErrorMessage = "Salary Coeffiecient is required to calculate salary")]
        public int SalaryCoefficient { set; get; }
       
        // Calculates the salary based on the type of employee that is created.
        public void SetSalary(int salaryCoefficient)
        {
            if (IsCEO)
            {
                Salary = salaryCoefficient * 2725;
 
            }
            else if (IsManager)
            {
                Salary = salaryCoefficient * 1725;
                
            }
            else
            {
                Salary = salaryCoefficient * 1125;
            }
        }
    }
}
