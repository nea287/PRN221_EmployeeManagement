using AutoMapper;
using EmployeeManagement_BusinessLayer.IServices;
using EmployeeManagement_BusinessLayer.Request.Plan;
using EmployeeManagement_BusinessLayer.ViewModels;
using EmployeeManagement_SWD392.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.Services
{
    public class PlanService : IPlanService
    {
        private readonly IMapper _mapper;
        private readonly SWD392_EmployeeManagementContext _context;

        public PlanService(IMapper mapper, SWD392_EmployeeManagementContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public ResponseResult<PlanViewModel> CreatePlan(PlanRequestModel plan)
        {
            throw new NotImplementedException();
        }

        public bool DeletePlan(string planCode)
        {
            throw new NotImplementedException();
        }

        public ResponseResult<PlanViewModel> GetPlan(string planCode)
        {
            throw new NotImplementedException();
        }

        public DynamicModelResponse.DynamicModelsResponse<PlanViewModel> GetPlans(int page, int size)
        {
            throw new NotImplementedException();
        }

        public ResponseResult<PlanViewModel> UpdatePlan(PlanRequestModel plan, string planCode)
        {
            throw new NotImplementedException();
        }
    }
}
