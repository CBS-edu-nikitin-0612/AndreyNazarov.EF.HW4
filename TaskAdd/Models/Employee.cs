using System;
using System.Collections.Generic;

namespace TaskAdd.Models
{
    public partial class Employee
    {
        public Employee()
        {
            InverseManagerEmp = new HashSet<Employee>();
            Orders = new HashSet<Order>();
        }

        public int EmployeeId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string Mname { get; set; } = null!;
        public decimal Salary { get; set; }
        public decimal PriorSalary { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public int? ManagerEmpId { get; set; }

        public virtual Employee? ManagerEmp { get; set; }
        public virtual ICollection<Employee> InverseManagerEmp { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
