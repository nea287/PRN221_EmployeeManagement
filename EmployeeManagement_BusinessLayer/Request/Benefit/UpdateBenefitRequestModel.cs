using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.Request.Benefit
{
    public class UpdateBenefitRequestModel
    {
        public int BenefitId { get; set; }
        public string? EmployeeId { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? Remarks { get; set; }
        public int? BenefitTypeId { get; set; }
    }
}
