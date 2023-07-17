using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeManagement_BusinessLayer.Common
{
    public enum AccountRoleEnum
    {
        [Display(Name = "Quản lý")]
        Manager = 1,
        [Display(Name = "Nhân viên")]
        Employee = 2,


    }

}
