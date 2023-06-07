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
        ResponseResult<BenefitViewModel> CreateBenefit(BenefitRequestModel benef);
        ResponseResult<BenefitViewModel> UpdateBenefit(BenefitRequestModel benef, int benefId);
        bool DeleteBenefit(int benefID);
    }
}
