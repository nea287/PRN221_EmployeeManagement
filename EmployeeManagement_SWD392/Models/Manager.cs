using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class Manager
    {
        public string EmployeeId { get; set; } = null!;
        public string? DirectorId { get; set; }
        public int? Status { get; set; }
        public string? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
        public virtual Director? Director { get; set; }
    }
}
