using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.ViewModels
{
    public class PlanViewModel
    {
        public string PlanCode { get; set; } = null!;
        public string? EmployeeId { get; set; }
        public DateTime? StartedDate { get; set; }
        public DateTime? Deadline { get; set; }
        public int? Status { get; set; }
    }
}
