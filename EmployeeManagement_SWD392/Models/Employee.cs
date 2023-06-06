using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Accounts = new HashSet<Account>();
            Achievements = new HashSet<Achievement>();
            Allowances = new HashSet<Allowance>();
            Attendances = new HashSet<Attendance>();
            Benefits = new HashSet<Benefit>();
            DateReports = new HashSet<DateReport>();
            Leaves = new HashSet<Leave>();
            MonthReports = new HashSet<MonthReport>();
            Performances = new HashSet<Performance>();
            Plans = new HashSet<Plan>();
        }

        public string EmployeeId { get; set; } = null!;
        public string? EmployeeName { get; set; }
        public int? EmployeeAge { get; set; }
        public string? Mail { get; set; }
        public string? EmployeeAddress { get; set; }
        public string? Phone { get; set; }
        public DateTime? DateOfHide { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Coach { get; set; }
        public string? DepartmentId { get; set; }
        public string? Country { get; set; }
        public int? Status { get; set; }
        public string? BankAccount { get; set; }

        public virtual Department? Department { get; set; }
        public virtual Director? Director { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<Allowance> Allowances { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Benefit> Benefits { get; set; }
        public virtual ICollection<DateReport> DateReports { get; set; }
        public virtual ICollection<Leave> Leaves { get; set; }
        public virtual ICollection<MonthReport> MonthReports { get; set; }
        public virtual ICollection<Performance> Performances { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
    }
}
