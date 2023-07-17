using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmployeeManagement_BusinessLayer.Common;
using EmployeeManagement_BusinessLayer.IServices;
using EmployeeManagement_BusinessLayer.Request.Attendance;
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
    public class AttendanceService : IAttendanceService
    {
        private readonly IMapper _mapper;
        private readonly SWD392_EmployeeManagementContext _context;

        public AttendanceService(IMapper mapper, SWD392_EmployeeManagementContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public ResponseResult<AttendanceViewModel> CreateAttendance(AttendanceRequestModel attend, string empCode, DateTime date)
        {
            Attendance attendance = null;
            try
            {
                attendance = _context.Attendances
                .FirstOrDefault(x => x.EmployeeId.Equals(empCode) && x.Date == date);

                if (attendance != null)
                {
                    _context.Entry(attendance).State = EntityState.Detached;
                    throw new Exception(Constraints.EXISTED_ATTENDANCE);
                }
                attendance = _mapper.Map<Attendance>(attend);
                _context.Entry(attendance).State = EntityState.Added;

                _context.Attendances.Add(attendance);

            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.FAILED_CREATE_ATTENDANCE);
            }

            return new ResponseResult<AttendanceViewModel>()
            {
                Message = Constraints.SUC_CREATE_ATTENDANCE,

                Value = _mapper.Map<AttendanceViewModel>(_context.Attendances
                .FirstOrDefault(x => x.EmployeeId.Equals(empCode)
                && x.Date == date))
            };
        }

        public bool DeleteAttendance(string empdCode, DateTime date)
        {
            try
            {
                Attendance attend = _context.Attendances
                    .FirstOrDefault(x => x.Date == date && x.EmployeeId.Equals(empdCode));

                if (attend == null)
                {
                    throw new Exception(Constraints.NOT_FOUND_ATTENDANCE);
                }

                attend.Status = 0;

                _context.Entry(attend).State = EntityState.Detached;
                _context.Entry(attend).State = EntityState.Modified;

                _context.Attendances.Update(attend);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.FAILED_DELETE_ATTENDANCE);
            }
            return true;
        }

        public ResponseResult<AttendanceViewModel> GetAttendance(string empCode, DateTime date)
        {
            Attendance attend = null;
            try
            {
                attend = _context.Attendances.FirstOrDefault(
                        x => x.EmployeeId.Equals(empCode) && x.Date == date);

            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.NOT_FOUND_ATTENDANCE);
            }

            _context.Entry(attend).State = EntityState.Detached;
            return new ResponseResult<AttendanceViewModel>()
            {
                Message = "Thông tin chấm công ngày " + date + ": ",
                Value = _mapper.Map<AttendanceViewModel>(attend)
            };
        }

        public DynamicModelResponse.DynamicModelsResponse<AttendanceViewModel> GetAttendances(int page, int size)
        {
            (int, IQueryable<AttendanceViewModel>) pagingAttend;
            try
            {
                pagingAttend = _context.Attendances
                    .ProjectTo<AttendanceViewModel>(_mapper.ConfigurationProvider)
                    .PagingIQueryable(page, size, Constraints.LimitPaging, Constraints.DefaultPaging);
            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.EMPTY_LIST);
            }

            return new DynamicModelResponse.DynamicModelsResponse<AttendanceViewModel>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = page,
                    Size = size,
                    Total = pagingAttend.Item1
                },
                Results = pagingAttend.Item2.ToList()
            };
        }

        public Task<AttendanceViewModel> TakeAttendance(AttendanceRequestModel model)
        {
            try
            {
                throw new Exception();
            }
            catch
            {
                throw new Exception(Constraints.FAILED_CREATE_ATTENDANCE);
            }
        }

        public ResponseResult<AttendanceViewModel> UpdateAttendance(AttendanceRequestModel attend, DateTime date, string empCode)
        {
            try
            {
                var findAttend = _context.Attendances
                    .FirstOrDefault(x => x.EmployeeId.Equals(empCode) && x.Date == date);

                if (findAttend == null)
                {
                    throw new Exception(Constraints.NOT_FOUND_ATTENDANCE);
                }

                Benefit benefit = _mapper.Map<Benefit>(attend);

                _context.Entry(findAttend).State = EntityState.Detached;
                _context.Entry(benefit).State = EntityState.Modified;
                _context.Benefits.Update(benefit);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.FAILED_UDPATE_ATTENDANCE);
            }

            return new ResponseResult<AttendanceViewModel>()
            {
                Message = Constraints.SUC_UPDATE_ATTENDANCE,
                Value = _mapper.Map<AttendanceViewModel>(attend)
            };
        }
    }
}
