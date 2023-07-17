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
        public async Task<ResponseResult<EmployeeViewModel>> CreateEmployee(CreateEmployeeRequestModel emp)
        {
            Employee emp1 = null;
            try
            {
                emp1 = _context.Employees
                    .FirstOrDefault(x => x.EmployeeId.Equals(emp.EmployeeId) && x.Status != 0);

                if (emp1 != null)
                {
                    _context.Entry(emp1).State = EntityState.Detached;
                    throw new Exception(Constraints.EXISTED_EMPLOYEE);
                }
                emp1 = _mapper.Map<Employee>(emp);
                
                _context.Entry(emp1).State = EntityState.Added;

                await _context.Employees.AddAsync(emp1);
                await _context.SaveChangesAsync();
                _context.Entry(emp1).State = EntityState.Detached;

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
                        x => x.EmployeeId.Equals(emp.EmployeeId) && x.Status != 0))
            };
        }

        public async Task<bool> DeleteAccount(string empCode)
        {
            try
            {
                Employee emp = _context.Employees
                    .FirstOrDefault(x => x.EmployeeId.Equals(empCode) && x.Status != 0);

                if (emp == null)
                {
                    throw new Exception(Constraints.NOT_FOUND_EMPLOYEE);
                }

                emp.Status = 0;

                _context.Entry(emp).State = EntityState.Detached;
                _context.Entry(emp).State = EntityState.Modified;

                _context.Employees.Update(emp);
                await _context.SaveChangesAsync();

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
                        x => x.EmployeeId.Equals(empCode) && x.Status != 0);

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
            (int, IQueryable<EmployeeViewModel>) pagingEmployee;
            try
            {
                pagingEmployee = _context.Employees.Where(x => x.Status != 0)
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
                    Total = pagingEmployee.Item1
                },
                Results = pagingEmployee.Item2.ToList()
            };
        }

        public async Task<ResponseResult<EmployeeViewModel>> UpdateEmployee(UpdateEmployeeRequestModel emp)
        {
            try
            {
                var findEmployee = _context.Employees
                    .FirstOrDefault(x => x.EmployeeId.Equals(emp.EmployeeId) && x.Status!= 0);

                if (findEmployee == null)
                {
                    throw new Exception(Constraints.NOT_FOUND_EMPLOYEE);
                }
                if (emp.Birthdate == null)
                {
                    emp.Birthdate = findEmployee.Birthdate;
                }
                if (emp.DateOfHide == null)
                {
                    emp.DateOfHide = findEmployee.DateOfHide;
                }
                if(emp.DepartmentId == "")
                {
                    emp.DepartmentId = findEmployee.DepartmentId;
                }
                Employee emp1 = _mapper.Map<Employee>(emp);

                _context.Entry(findEmployee).State = EntityState.Detached;
                _context.Entry(emp1).State = EntityState.Modified;
                _context.Employees.Update(emp1);
                await _context.SaveChangesAsync();
                _context.Entry(emp1).State = EntityState.Detached;
            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.FAILED_UPDATE_EMPLOYEE);
            }

            return new ResponseResult<EmployeeViewModel>()
            {
                Message = Constraints.SUC_UPDATE_EMPLOYEE,
                Value = _mapper.Map<EmployeeViewModel>(emp)
            };
        }
    }
}
