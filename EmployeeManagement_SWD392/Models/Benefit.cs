using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class Benefit
    {
        public int BenefitId { get; set; }
        public string? EmployeeId { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? Remarks { get; set; }
        public int? BenefitTypeId { get; set; }

        public virtual BenefitType? BenefitType { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
