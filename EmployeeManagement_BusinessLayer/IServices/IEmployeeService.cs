using EmployeeManagement_BusinessLayer.Request.Account;
using EmployeeManagement_BusinessLayer.Request.Employee;
using EmployeeManagement_BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.IServices
{
    public interface IEmployeeService
    {
        ResponseResult<EmployeeViewModel> GetEmployeeByCode(string empCode);
        DynamicModelResponse.DynamicModelsResponse<EmployeeViewModel> GetEmployees(int page, int size);
        ResponseResult<EmployeeViewModel> CreateEmployee(CreateEmployeeRequestModel emp);
        ResponseResult<EmployeeViewModel> UpdateEmployee(UpdateEmployeeRequestModel emp);
        bool DeleteAccount(string empCode);
    }
}
