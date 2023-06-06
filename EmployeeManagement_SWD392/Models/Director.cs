using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class Director
    {
        public Director()
        {
            Departments = new HashSet<Department>();
            Managers = new HashSet<Manager>();
        }

        public string EmployeeId { get; set; } = null!;
        public int? Status { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
    }
}
