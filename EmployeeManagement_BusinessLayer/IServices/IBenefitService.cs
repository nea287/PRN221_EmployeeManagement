using EmployeeManagement_BusinessLayer.Request.Benefit;
using EmployeeManagement_BusinessLayer.Request.Employee;
using EmployeeManagement_BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.IServices
{
    public interface IBenefitService  
    { 
        ResponseResult<BenefitViewModel> GetBenefit(int benefID);
        DynamicModelResponse.DynamicModelsResponse<BenefitViewModel> GetBenefits(int page, int size);
        Task<ResponseResult<BenefitViewModel>> CreateBenefit(BenefitRequestModel benef);
        Task<bool> DeleteBenefit(int benefID);
        Task<ResponseResult<BenefitViewModel>> UpdateBenefit(UpdateBenefitRequestModel model);
    }
}
