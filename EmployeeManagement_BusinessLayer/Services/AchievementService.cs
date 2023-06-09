using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmployeeManagement_BusinessLayer.Common;
using EmployeeManagement_BusinessLayer.IServices;
using EmployeeManagement_BusinessLayer.Request.Achievement;
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

    public class AchievementService : IAchievementService
    {
        private readonly IMapper _mapper;
        private readonly SWD392_EmployeeManagementContext _context;

        public AchievementService(IMapper mapper, SWD392_EmployeeManagementContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public ResponseResult<AchievementViewModel> CreateAchievement(AchievementRequestModel achie)
        {
            Achievement achievement = null;
            try
            {
                achievement = _context.Achievements
                .FirstOrDefault(x => x.AchievementCode.Equals(achie.AchievementCode));

                if (achievement != null)
                {
                    _context.Entry(achievement).State = EntityState.Detached;
                    throw new Exception(Constraints.EXISTED_ACHIEVEMENT);
                }
                achievement = _mapper.Map<Achievement>(achie);
                _context.Entry(achievement).State = EntityState.Added;

                _context.Achievements.Add(achievement);

            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.FAILED_CREATE_ACHIEVEMENT);
            }

            return new ResponseResult<AchievementViewModel>()
            {
                Message = Constraints.SUC_CREATE_ACHIEVEMENT,

                Value = _mapper.Map<AchievementViewModel>(_context.Achievements
                .FirstOrDefault(x => x.AchievementCode.Equals(achie.AchievementCode)))
            };
        }

        //public bool DeleteAchievement(string achieCode)
        //{
        //    try
        //    {
        //        Achievement ache = _context.Achievements
        //            .FirstOrDefault(x => x.AchievementCode.Equals(achieCode));

        //        if (ache == null)
        //        {
        //            throw new Exception(Constraints.NOT_FOUND_BENEFIT);
        //        }

        //        ache.Status = 0;

        //        _context.Entry(benef).State = EntityState.Detached;
        //        _context.Entry(benef).State = EntityState.Modified;

        //        _context.Benefits.Update(benef);
        //        _context.SaveChanges();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(Constraints.FAILED_DELETE_BENEFIT);
        //    }
        //    return true;
        //}

        public ResponseResult<AchievementViewModel> GetAchievement(string achieCode)
        {
            Achievement achie = null;
            try
            {
                achie = _context.Achievements.FirstOrDefault(
                        x => x.AchievementCode.Equals(achieCode));

            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.NOT_FOUND_ACHIEVEMENT);
            }

            _context.Entry(achie).State = EntityState.Detached;
            return new ResponseResult<AchievementViewModel>()
            {
                Message = "Thành tựu " + achie.AchievementName,
                Value = _mapper.Map<AchievementViewModel>(achie)
            };
        }

        public DynamicModelResponse.DynamicModelsResponse<AchievementViewModel> GetAchievements(int page, int size)
        {
            (int, IQueryable<AchievementViewModel>) pagingAchie;
            try
            {
                pagingAchie = _context.Achievements
                    .ProjectTo<AchievementViewModel>(_mapper.ConfigurationProvider)
                    .PagingIQueryable(page, size, Constraints.LimitPaging, Constraints.DefaultPaging);
            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.EMPTY_LIST);
            }

            return new DynamicModelResponse.DynamicModelsResponse<AchievementViewModel>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = page,
                    Size = size,
                    Total = pagingAchie.Item1
                },
                Results = pagingAchie.Item2.ToList()
            };
        }

        public ResponseResult<AchievementViewModel> UpdateAchievement(AchievementRequestModel achie, string achieCode)
        {
            try
            {
                var findAchie = _context.Achievements
                    .FirstOrDefault(x => x.AchievementCode.Equals(achieCode));

                if (findAchie == null)
                {
                    throw new Exception(Constraints.NOT_FOUND_BENEFIT);
                }

                Achievement achievement = _mapper.Map<Achievement>(achie);

                _context.Entry(findAchie).State = EntityState.Detached;
                _context.Entry(achievement).State = EntityState.Modified;
                _context.Achievements.Update(achievement);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.FAILED_UDPATE_ACHIEVEMENT);
            }

            return new ResponseResult<AchievementViewModel>()
            {
                Message = Constraints.SUC_UPDATE_ACHIEVEMENT,
                Value = _mapper.Map<AchievementViewModel>(achie)
            };
        }
    }
}
