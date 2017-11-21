using System;
using System.Collections.Generic;

namespace WebApiCore.Model.Data
{
    public partial class Employee
    {
        public Employee()
        {
            DeptEmp = new HashSet<DeptEmp>();
            DeptManager = new HashSet<DeptManager>();
            Salaries = new HashSet<Salaries>();
            Titles = new HashSet<Titles>();
        }

        public int EmpNo { get; set; }
        public DateTime? BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }

        public DateTime? HireDate { get; set; }

        public ICollection<DeptEmp> DeptEmp { get; set; }
        public ICollection<DeptManager> DeptManager { get; set; }
        public ICollection<Salaries> Salaries { get; set; }
        public ICollection<Titles> Titles { get; set; }
    }
}
