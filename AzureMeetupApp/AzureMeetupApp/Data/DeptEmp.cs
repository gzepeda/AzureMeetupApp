using System;
using System.Collections.Generic;

namespace WebApiCore.Model.Data
{
    public partial class DeptEmp
    {
        public int EmpNo { get; set; }
        public string DeptNo { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public Departments DeptNoNavigation { get; set; }
        public Employee EmpNoNavigation { get; set; }
    }
}
