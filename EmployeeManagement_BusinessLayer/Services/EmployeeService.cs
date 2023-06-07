using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmployeeManagement_BusinessLayer.Common;
using EmployeeManagement_BusinessLayer.IServices;
using EmployeeManagement_BusinessLayer.Request.Employee;
using EmployeeManagement_BusinessLayer.Utilities;
using EmployeeManagement_BusinessLayer.ViewModels;
using EmployeeManagement_SWD392.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.Services
{
    
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly SWD392_EmployeeManagementContext _context;

        public EmployeeService(IMapper mapper, SWD392_EmployeeManagementContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public ResponseResult<EmployeeViewModel> CreateEmployee(CreateEmployeeRequestModel emp)
        {
            Employee emp1 = null;
            try
            {
                emp1 = _context.Employees
                    .FirstOrDefault(x => x.EmployeeId.Equals(emp.EmployeeId));

                if (emp != null)
                {
                    _context.Entry(emp1).State = EntityState.Detached;
                    throw new Exception(Constraints.EXISTED_EMPLOYEE);
                }
                emp1 = _mapper.Map<Employee>(emp);
                _context.Entry(emp1).State = EntityState.Added;

                _context.Employees.Add(emp1);

            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.FAILED_CREATE_EMPLOYEE);
            }

            return new ResponseResult<EmployeeViewModel>()
            {
                Message = Constraints.SUC_CREATE_EMPLOYEE,

                Value = _mapper.Map<EmployeeViewModel>(
                    _context.Accounts.FirstOrDefault(
                        x => x.EmployeeId.Equals(emp.EmployeeId)))
            };
        }

        public bool DeleteAccount(string empCode)
        {
            try
            {
                Employee emp = _context.Employees
                    .FirstOrDefault(x => x.EmployeeId.Equals(empCode));

                if (emp == null)
                {
                    throw new Exception(Constraints.NOT_FOUND_EMPLOYEE);
                }

                emp.Status = 0;

                _context.Entry(emp).State = EntityState.Detached;
                _context.Entry(emp).State = EntityState.Modified;

                _context.Accounts.Update(emp);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.FAILED_DELETE_EMPLOYEE);
            }
            return true;
        }

        public ResponseResult<EmployeeViewModel> GetEmployeeByCode(string empCode)
        {
            Employee emp = null;
            try
            {
                emp = _context.Employees.FirstOrDefault(
                        x => x.EmployeeId == empCode);

            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.NOT_FOUND_EMPLOYEE);
            }

            _context.Entry(emp).State = EntityState.Detached;
            return new ResponseResult<EmployeeViewModel>()
            {
                Message = "Xin chào! " + emp.EmployeeName,
                Value = _mapper.Map<EmployeeViewModel>(emp)
            };

        }

        public DynamicModelResponse.DynamicModelsResponse<EmployeeViewModel> GetEmployees(int page, int size)
        {
            (int, IQueryable<EmployeeViewModel>) pagingAccount;
            try
            {
                pagingAccount = _context.Employees.Where(x => x.Status != 0)
                    .ProjectTo<EmployeeViewModel>(_mapper.ConfigurationProvider)
                    .PagingIQueryable(page, size, Constraints.LimitPaging, Constraints.DefaultPaging);
            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.EMPTY_LIST);
            }

            return new DynamicModelResponse.DynamicModelsResponse<EmployeeViewModel>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = page,
                    Size = size,
                    Total = pagingAccount.Item1
                },
                Results = pagingAccount.Item2.ToList()
            };
        }

        public ResponseResult<EmployeeViewModel> UpdateEmployee(UpdateEmployeeRequestModel emp)
        {
            try
            {
                var findEmployee = _context.Employees
                    .FirstOrDefault(x => x.EmployeeId.Equals(emp.EmployeeId));

                if (findEmployee == null)
                {
                    throw new Exception(Constraints.NOT_FOUND_EMPLOYEE);
                }

                Employee emp1 = _mapper.Map<Employee>(emp);

                _context.Entry(findEmployee).State = EntityState.Detached;
                _context.Entry(emp1).State = EntityState.Modified;
                _context.Employees.Update(emp1);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.FAILED_UPDATE);
            }

            return new ResponseResult<AccountViewModel>()
            {
                Message = Constraints.SUC_UPDATE,
                Value = _mapper.Map<AccountViewModel>(acc)
            };
        }
    }
}
