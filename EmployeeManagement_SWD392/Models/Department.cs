using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
            Managers = new HashSet<Manager>();
        }

        public string DepartmentId { get; set; } = null!;
        public string? DepartmentName { get; set; }
        public string? DirectorId { get; set; }
        public int Status { get; set; }

        public virtual Director? Director { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
    }
}
