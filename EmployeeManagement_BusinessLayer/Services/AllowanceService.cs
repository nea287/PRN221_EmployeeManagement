using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmployeeManagement_BusinessLayer.Common;
using EmployeeManagement_BusinessLayer.IServices;
using EmployeeManagement_BusinessLayer.Request.Allowance;
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
    public class AllowanceService : IAllowanceService
    {
        private readonly IMapper _mapper;
        private readonly SWD392_EmployeeManagementContext _context;

        public AllowanceService(IMapper mapper, SWD392_EmployeeManagementContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public ResponseResult<AllowanceViewModel> CreateAllowance(AllowanceRequestModel allow)
        {
            Allowance allowance = null;
            try
            {
                allowance = _context.Allowances
                .FirstOrDefault(x => x.EmployeeId.Equals(allow.EmployeeId)
                && x.AllowanceTypeId == allow.AllowanceTypeId && x.Status != 0);

                if (allowance != null)
                {
                    _context.Entry(allowance).State = EntityState.Detached;
                    throw new Exception(Constraints.EXISTED_ALLOWANCE);
                }
                allowance = _mapper.Map<Allowance>(allow);
                _context.Entry(allowance).State = EntityState.Added;

                _context.Allowances.Add(allowance);

            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.FAILED_CREATE_ALLOWANCE);
            }

            return new ResponseResult<AllowanceViewModel>()
            {
                Message = Constraints.SUC_CREATE_ALLOWANCE,

                Value = _mapper.Map<AllowanceViewModel>(_context.Allowances
                .FirstOrDefault(x => x.EmployeeId.Equals(allow.EmployeeId)
                && x.AllowanceTypeId == allow.AllowanceTypeId && x.Status != 0))
            };
        }

        public bool DeleteAllowance(int allId)
        {
            try
            {
                Allowance allow = _context.Allowances
                    .FirstOrDefault(x => x.AllowanceId == allId && x.Status != 0); ;

                if (allow == null)
                {
                    throw new Exception(Constraints.NOT_FOUND_ALLOWANCE);
                }

                allow.Status = 0;

                _context.Entry(allow).State = EntityState.Detached;
                _context.Entry(allow).State = EntityState.Modified;

                _context.Allowances.Update(allow);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.FAILED_DELETE_ALLOWANCE);
            }
            return true;
        }

        public ResponseResult<AllowanceViewModel> GetAllowance(int allId)
        {
            Allowance all = null;
            try
            {
                all = _context.Allowances.FirstOrDefault(
                        x => x.AllowanceId == allId && x.Status != 0);

            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.NOT_FOUND_ALLOWANCE);
            }

            _context.Entry(all).State = EntityState.Detached;
            return new ResponseResult<AllowanceViewModel>()
            {
                Message = "Trợ cấp " + all.AllowanceType.AllowanceTypeName,
                Value = _mapper.Map<AllowanceViewModel>(all)
            };
        }

        public DynamicModelResponse.DynamicModelsResponse<AllowanceViewModel> GetAllowances(int page, int size)
        {
            (int, IQueryable<AllowanceViewModel>) pagingAllowance;
            try
            {
                pagingAllowance = _context.Allowances.Where(x => x.Status != 0)
                    .ProjectTo<AllowanceViewModel>(_mapper.ConfigurationProvider)
                    .PagingIQueryable(page, size, Constraints.LimitPaging, Constraints.DefaultPaging);
            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.EMPTY_LIST);
            }

            return new DynamicModelResponse.DynamicModelsResponse<AllowanceViewModel>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = page,
                    Size = size,
                    Total = pagingAllowance.Item1
                },
                Results = pagingAllowance.Item2.ToList()
            };
        }

        public ResponseResult<AllowanceViewModel> UpdateAllowance(AllowanceRequestModel allow, int allId)
        {
            try
            {
                var findAllowance = _context.Allowances
                    .FirstOrDefault(x => x.AllowanceId == allId && x.Status != 0);

                if (findAllowance == null)
                {
                    throw new Exception(Constraints.NOT_FOUND_ALLOWANCE);
                }

                Allowance allowance = _mapper.Map<Allowance>(allow);

                _context.Entry(findAllowance).State = EntityState.Detached;
                _context.Entry(allowance).State = EntityState.Modified;
                _context.Allowances.Update(allowance);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.FAILED_UDPATE_ALLOWANCE);
            }

            return new ResponseResult<AllowanceViewModel>()
            {
                Message = Constraints.SUC_UPDATE_ALLOWANCE,
                Value = _mapper.Map<AllowanceViewModel>(allow)
            };
        }
    }
}

