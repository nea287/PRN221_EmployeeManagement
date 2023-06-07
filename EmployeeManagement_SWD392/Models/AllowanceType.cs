using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class AllowanceType
    {
        public AllowanceType()
        {
            Allowances = new HashSet<Allowance>();
        }

        public string AllowanceTypeId { get; set; } = null!;
        public string? AllowanceTypeName { get; set; }
        public string? AllowanceTypeDescription { get; set; }
        public decimal? AllowanceAmount { get; set; }
        public int? Status { get;set; }

        public virtual ICollection<Allowance> Allowances { get; set; }
    }
}
