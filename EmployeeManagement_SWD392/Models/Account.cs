using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? EmployeeId { get; set; }
        public int? Status { get; set; }
        public string? RoleCode { get; set; }
        public decimal? Salary { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual Role? RoleCodeNavigation { get; set; }
    }
}
