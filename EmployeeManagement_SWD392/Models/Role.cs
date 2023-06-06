using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }

        public string RoleCode { get; set; } = null!;
        public string? RoleName { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
