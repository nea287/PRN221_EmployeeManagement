using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class Achievement
    {
        public string AchievementCode { get; set; } = null!;
        public string? AchievementName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
