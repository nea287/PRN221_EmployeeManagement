using EmployeeManagement_BusinessLayer.Request.Attendance;
using EmployeeManagement_BusinessLayer.Request.Benefit;
using EmployeeManagement_BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.IServices
{
    public interface IAttendanceService
    {
        ResponseResult<AttendanceViewModel> GetAttendance(string empCode, DateTime date);
        DynamicModelResponse.DynamicModelsResponse<AttendanceViewModel> GetAttendances(int page, int size);
        ResponseResult<AttendanceViewModel> CreateAttendance(AttendanceRequestModel attend, string empCode, DateTime date);
        ResponseResult<AttendanceViewModel> UpdateAttendance(AttendanceRequestModel attend, DateTime date, string empCode);
        bool DeleteAttendance(string empdCode, DateTime date);
    }
}
