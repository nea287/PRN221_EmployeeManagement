using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.Request.Allowance
{
    public class AllowanceRequestModel
    {
        public string? EmployeeId { get; set; }
        public string? AllowanceTypeId { get; set; }
        public DateTime? AllowanceDate { get; set; }
        public string? Remarks { get; set; }
    }
}
