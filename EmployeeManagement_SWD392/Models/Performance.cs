using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class Performance
    {
        public string PerformanceId { get; set; } = null!;
        public string? EmployeeId { get; set; }
        public DateTime? DatePerf { get; set; }
        public double? PerformanceRatingf { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
