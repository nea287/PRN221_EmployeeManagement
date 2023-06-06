using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class Leave
    {
        public string LeaveId { get; set; } = null!;
        public string? EmployeeId { get; set; }
        public int? LeaveType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual LeaveType? LeaveTypeNavigation { get; set; }
    }
}
