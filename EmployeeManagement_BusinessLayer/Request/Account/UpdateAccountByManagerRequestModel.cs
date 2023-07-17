using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.Request.Account
{
    public class UpdateAccountByManagerRequestModel
    {
        public int AccountId { get; set; }
        public string? Username { get; set; }
        public string? EmployeeId { get; set; }
        public int? RoleCode { get; set; }
        public decimal? Salary { get; set; }
    }
}
