using AutoMapper;
using EmployeeManagement_BusinessLayer.IServices;
using EmployeeManagement_SWD392.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IMapper _mapper;
        private readonly SWD392_EmployeeManagementContext _context;

        public ManagerService(IMapper mapper, SWD392_EmployeeManagementContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public BenefitService GetBenefitService()
        {
            return new BenefitService(_mapper, _context);
        }
        public EmployeeService GetEmployeeService()
        {
            return new EmployeeService(_mapper, _context);  
        }
        public AccountService GetAccountService()
        {
            return new AccountService(_mapper, _context);
        }
    }
}
