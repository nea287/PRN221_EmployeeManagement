using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.Request.Attendance
{
    public class AttendanceRequestModel
    {
        //public DateTime Date { get; set; }
        //public string EmployeeId { get; set; } = null!;
        public TimeSpan? TimeIn { get; set; }
        public TimeSpan? TimeOut { get; set; }
        public double? TotalHours { get; set; }
        public double? OvertimeHours { get; set; }
        public int? AttendanceStatus { get; set; }
        public string? Address { get; set; }
        public int? LeaveType { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
    }
}
