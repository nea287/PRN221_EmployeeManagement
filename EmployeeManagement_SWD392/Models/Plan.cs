using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class Plan
    {
        public string PlanCode { get; set; } = null!;
        public string? EmployeeId { get; set; }
        public DateTime? StartedDate { get; set; }
        public DateTime? Deadline { get; set; }
        public int? Status { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
