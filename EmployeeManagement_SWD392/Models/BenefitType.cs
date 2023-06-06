using System;
using System.Collections.Generic;

namespace EmployeeManagement_SWD392.Models
{
    public partial class BenefitType
    {
        public BenefitType()
        {
            Benefits = new HashSet<Benefit>();
        }

        public int BenefitTypeId { get; set; }
        public string? BenefitTypeName { get; set; }
        public string? Description { get; set; }
        public decimal? BenefitAmount { get; set; }

        public virtual ICollection<Benefit> Benefits { get; set; }
    }
}
