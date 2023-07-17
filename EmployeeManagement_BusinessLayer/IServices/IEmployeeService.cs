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
        Task<ResponseResult<EmployeeViewModel>> CreateEmployee(CreateEmployeeRequestModel emp);
        Task<ResponseResult<EmployeeViewModel>> UpdateEmployee(UpdateEmployeeRequestModel emp);
        Task<bool> DeleteAccount(string empCode);
    }
}
