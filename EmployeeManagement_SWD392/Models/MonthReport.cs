using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class MonthReport
    {
        public string Month { get; set; } = null!;
        public string? EmployeeId { get; set; }
        public decimal? Salary { get; set; }
        public decimal? Fine { get; set; }
        public double? Tax { get; set; }
        public decimal? FinalSalary { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
