using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class DateReport
    {
        public DateTime Date { get; set; }
        public string? EmployeeId { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string? RuleAwardId { get; set; }
        public string? RuleDisciplinaryId { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual RuleAward? RuleAward { get; set; }
        public virtual RuleDisciplinary? RuleDisciplinary { get; set; }
    }
}
