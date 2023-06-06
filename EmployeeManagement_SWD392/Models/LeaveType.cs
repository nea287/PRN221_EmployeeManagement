using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class LeaveType
    {
        public LeaveType()
        {
            Attendances = new HashSet<Attendance>();
            Leaves = new HashSet<Leave>();
        }

        public int LeaveType1 { get; set; }
        public string? LeaveTypeName { get; set; }
        public string? Description { get; set; }
        public decimal? Penalty { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Leave> Leaves { get; set; }
    }
}
