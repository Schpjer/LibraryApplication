using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.DTO
{
    public class EmployeeDTO
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public double Salary { set; get; }

        public EmployeeDTO(string firstName, string lastName, double salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }
    }
}
