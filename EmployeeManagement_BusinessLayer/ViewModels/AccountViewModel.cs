using EmployeeManagement_SWD392.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.ViewModels
{
    public class AccountViewModel
    {
        public int AccountId { get; set; }
        public string? Username { get; set; }
        //public string? Password { get; set; }
        public string? EmployeeId { get; set; }
        public int? Status { get; set; }
        public int? RoleCode { get; set; }
        public decimal? Salary { get; set; }

        //public virtual Employee? Employee { get; set; }
        //public virtual Role? RoleCodeNavigation { get; set; }
    }
}
