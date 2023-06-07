using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.Request.Account
{
    public class CreateAccountRequestModel
    {
        //public int AccountId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? EmployeeId { get; set; }
        public int? Status { get; set; }
        public string? RoleCode { get; set; }
        public decimal? Salary { get; set; }
    }
}
