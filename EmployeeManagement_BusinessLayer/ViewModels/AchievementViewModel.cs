using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.ViewModels
{
    public class AchievementViewModel
    {
        public string AchievementCode { get; set; } = null!;
        public string? AchievementName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? EmployeeId { get; set; }
    }
}
