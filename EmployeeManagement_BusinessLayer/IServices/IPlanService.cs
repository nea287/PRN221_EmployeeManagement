using EmployeeManagement_BusinessLayer.Request.Benefit;
using EmployeeManagement_BusinessLayer.Request.Plan;
using EmployeeManagement_BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.IServices
{
    public interface IPlanService
    {
        ResponseResult<PlanViewModel> GetPlan(string planCode);
        DynamicModelResponse.DynamicModelsResponse<PlanViewModel> GetPlans(int page, int size);
        ResponseResult<PlanViewModel> CreatePlan(PlanRequestModel plan);
        ResponseResult<PlanViewModel> UpdatePlan(PlanRequestModel plan, string planCode);
        bool DeletePlan(string planCode);
    }
}
