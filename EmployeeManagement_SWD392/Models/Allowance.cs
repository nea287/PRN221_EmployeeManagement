using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class Allowance
    {
        public int AllowanceId { get; set; }
        public string? EmployeeId { get; set; }
        public string? AllowanceTypeId { get; set; }
        public DateTime? AllowanceDate { get; set; }
        public string? Remarks { get; set; }

        public virtual AllowanceType? AllowanceType { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
