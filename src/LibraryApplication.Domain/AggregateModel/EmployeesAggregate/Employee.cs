using LibraryApplication.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApplication.Domain.AggregateModel.EmployeesAggregate
{
    public class Employee: Entity
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public double Salary { set; get; }
        public bool IsCEO { set; get; }
        public bool IsManager { set; get; }
        public int ManagerId { set; get; }
    }
}
