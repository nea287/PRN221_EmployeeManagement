using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class Attendance
    {
        public DateTime Date { get; set; }
        public string EmployeeId { get; set; } = null!;
        public TimeSpan? TimeIn { get; set; }
        public TimeSpan? TimeOut { get; set; }
        public double? TotalHours { get; set; }
        public double? OvertimeHours { get; set; }
        public int? AttendanceStatus { get; set; }
        public int? LeaveType { get; set; }
        public string? Remarks { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual LeaveType? LeaveTypeNavigation { get; set; }
    }
}
