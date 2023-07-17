using EmployeeManagement_BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.IServices
{
    public interface IManagerService
    {
        //public T GetAccount();
        //public T GetBenefit();
        public BenefitService GetBenefitService();
        public EmployeeService GetEmployeeService();
        public AccountService GetAccountService();

    }
}
