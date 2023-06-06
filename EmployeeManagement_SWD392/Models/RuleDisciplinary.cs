using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class RuleDisciplinary
    {
        public RuleDisciplinary()
        {
            DateReports = new HashSet<DateReport>();
        }

        public string RuleDisciplinaryId { get; set; } = null!;
        public string? RuleDisciplinaryName { get; set; }
        public double? PercentOfDisciplinary { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<DateReport> DateReports { get; set; }
    }
}
