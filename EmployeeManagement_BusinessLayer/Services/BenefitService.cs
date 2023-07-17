using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmployeeManagement_BusinessLayer.Common;
using EmployeeManagement_BusinessLayer.IServices;
using EmployeeManagement_BusinessLayer.Request.Benefit;
using EmployeeManagement_BusinessLayer.Utilities;
using EmployeeManagement_BusinessLayer.ViewModels;
using EmployeeManagement_SWD392.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.Services
{
    public class BenefitService : IBenefitService
    {
        private readonly IMapper _mapper;
        private readonly SWD392_EmployeeManagementContext _context;

        public BenefitService(IMapper mapper, SWD392_EmployeeManagementContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ResponseResult<BenefitViewModel>> CreateBenefit(BenefitRequestModel bebef)
        {
            Benefit benefit = null;
            try
            {
                benefit = _context.Benefits
                .FirstOrDefault(x => x.EmployeeId.Equals(bebef.EmployeeId) 
                && x.BenefitTypeId == bebef.BenefitTypeId && x.Status != 0);

                if (benefit != null)
                {
                    _context.Entry(benefit).State = EntityState.Detached;
                    throw new Exception(Constraints.EXISTED_BENEFIT);
                }
                benefit = _mapper.Map<Benefit>(bebef);
                _context.Entry(benefit).State = EntityState.Added;

                await _context.Benefits.AddAsync(benefit);
                await _context.SaveChangesAsync();  

            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.FAILED_CREATE_BENEFIT);
            }

            return new ResponseResult<BenefitViewModel>()
            {
                Message = Constraints.SUC_CREATE_BENEFIT,

                Value = _mapper.Map<BenefitViewModel>(_context.Benefits
                .FirstOrDefault(x => x.EmployeeId.Equals(bebef.EmployeeId)
                && x.BenefitTypeId == bebef.BenefitTypeId && x.Status != 0))
            };
        }

        public async Task<bool> DeleteBenefit(int benefID)
        {
            try
            {
                Benefit benef = _context.Benefits
                    .FirstOrDefault(x => x.BenefitId == benefID && x.Status != 0);

                if (benef == null)
                {
                    throw new Exception(Constraints.NOT_FOUND_BENEFIT);
                }

                benef.Status = 0;

                _context.Entry(benef).State = EntityState.Detached;
                _context.Entry(benef).State = EntityState.Modified;

                _context.Benefits.Update(benef);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.FAILED_DELETE_BENEFIT);
            }
            return true;
        }

        public ResponseResult<BenefitViewModel> GetBenefit(int benefID)
        {
            Benefit benefit = null;
            try
            {
                benefit = _context.Benefits.FirstOrDefault(
                        x => x.BenefitId == benefID && x.Status != 0);

            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.NOT_FOUND_BENEFIT);
            }

            _context.Entry(benefit).State = EntityState.Detached;
            return new ResponseResult<BenefitViewModel>()
            {
                Message = "Phúc lọi " + benefit.BenefitType.BenefitTypeName,
                Value = _mapper.Map<BenefitViewModel>(benefit)
            };
        }

        public DynamicModelResponse.DynamicModelsResponse<BenefitViewModel> GetBenefits(int page, int size)
        {
            (int, IQueryable<BenefitViewModel>) pagingBenefit;
            try
            {
                pagingBenefit = _context.Benefits.Where(x => x.Status != 0)
                    .ProjectTo<BenefitViewModel>(_mapper.ConfigurationProvider)
                    .PagingIQueryable(page, size, Constraints.LimitPaging, Constraints.DefaultPaging);
            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.EMPTY_LIST);
            }

            return new DynamicModelResponse.DynamicModelsResponse<BenefitViewModel>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = page,
                    Size = size,
                    Total = pagingBenefit.Item1
                },
                Results = pagingBenefit.Item2.ToList()
            };
        }


        public async Task<ResponseResult<BenefitViewModel>> UpdateBenefit(UpdateBenefitRequestModel model)
        {
            try
            {
                var model1 = _context.Benefits
                    .FirstOrDefault(x => x.BenefitId == model.BenefitId  && x.Status != 0);

                if (model1 == null)
                {
                    throw new Exception(Constraints.NOT_FOUND_BENEFIT);
                }
                
                Benefit benefit = _mapper.Map<Benefit>(model);
                if (benefit.ReceivedDate == null)
                {
                    benefit.ReceivedDate = model1.ReceivedDate;
                }
                benefit.Status = 1;
                _context.Entry(model1).State = EntityState.Detached;
                _context.Entry(benefit).State = EntityState.Modified;
                _context.Benefits.Update(benefit);

                await _context.SaveChangesAsync();
                _context.Entry(benefit).State = EntityState.Detached;



            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.FAILED_UPDATE);
            }

            return new ResponseResult<BenefitViewModel>()
            {
                Message = Constraints.SUC_UPDATE,
                Value = _mapper.Map<BenefitViewModel>(model)
            };
        }
    }
}
