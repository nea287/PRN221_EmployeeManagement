using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class RuleAward
    {
        public RuleAward()
        {
            DateReports = new HashSet<DateReport>();
        }

        public string RuleAwardId { get; set; } = null!;
        public string? RuleAwardName { get; set; }
        public double? PercentOfAward { get; set; }
        public double? Tax { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<DateReport> DateReports { get; set; }
    }
}
