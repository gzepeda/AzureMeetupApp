using System;
using System.Collections.Generic;

namespace WebApiCore.Model.Data
{
    public partial class Departments
    {
        public Departments()
        {
            DeptEmp = new HashSet<DeptEmp>();
            DeptManager = new HashSet<DeptManager>();
        }

        public string DeptNo { get; set; }
        public string DeptName { get; set; }

        public ICollection<DeptEmp> DeptEmp { get; set; }
        public ICollection<DeptManager> DeptManager { get; set; }
    }
}
