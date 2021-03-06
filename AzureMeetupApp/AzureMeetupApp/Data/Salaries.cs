﻿using System;
using System.Collections.Generic;

namespace WebApiCore.Model.Data
{
    public partial class Salaries
    {
        public int EmpNo { get; set; }
        public int Salary { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public Employee EmpNoNavigation { get; set; }
    }
}
