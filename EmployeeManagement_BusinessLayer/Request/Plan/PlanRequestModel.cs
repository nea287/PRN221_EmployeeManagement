using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.Request.Plan
{
    public class PlanRequestModel
    {
        public string? EmployeeId { get; set; }
        public DateTime? StartedDate { get; set; }
        public DateTime? Deadline { get; set; }
        public int? Status { get; set; }
    }
}
