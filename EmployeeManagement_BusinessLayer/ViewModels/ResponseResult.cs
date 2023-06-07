using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.ViewModels
{
    public class ResponseResult <T>
    {
        public string? Message { get; set;  }
        public T? Value { get; set; }
    }
}
