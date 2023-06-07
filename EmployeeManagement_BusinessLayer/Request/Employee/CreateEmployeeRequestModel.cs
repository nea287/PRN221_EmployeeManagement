using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.Request.Employee
{
    public class CreateEmployeeRequestModel
    {
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
    }
}
