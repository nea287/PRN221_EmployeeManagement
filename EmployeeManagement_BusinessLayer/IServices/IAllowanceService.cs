using EmployeeManagement_BusinessLayer.Request.Allowance;
using EmployeeManagement_BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.IServices
{
    public interface IAllowanceService
    {
        ResponseResult<AllowanceViewModel> GetAllowance(int allId);
        DynamicModelResponse.DynamicModelsResponse<AllowanceViewModel> GetAllowances(int page, int size);
        ResponseResult<AllowanceViewModel> CreateAllowance(AllowanceRequestModel allow);
        ResponseResult<AllowanceViewModel> UpdateAllowance(AllowanceRequestModel allow, int allId);
        bool DeleteAllowance(int allId);
    }
}
