﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.Common
{
    public class Constraints
    {
        //Account
        public const string FAILED_LOGIN = "Sai username hoặc password rồi ạ!";
        public const string NOT_FOUND_ACCOUNT = "Không tìm thấy tài khoản có thông tin tương tự ạ";
        public const string EMPTY_LIST = "Danh trống hiện đang trống!";
        public const string SUC_LOGIN = "Đăng nhập tài khoản thành công!";
        public const string SUC_UPDATE = "Cập nhật tài khoản thành công!";
        public const string FAILED_UPDATE = "Cập nhật tài khoản thất bại!";
        public const string SUC_CREATE = "Tạo tài khoản thành công!";
        public const string FAILED_CREATE = "Tạo tài khoản thất bại!";
        public const string SUC_DELETE = "Xóa tài khoản thành công!";
        public const string FAILED_DELETE = "Xóa tài khoản thất bại!";
        public const string EXISTED_ACCOUNT = "Tài khoản đã tồn tại!";

        //Page
        public const int DefaultPaging = 50;
        public const int LimitPaging = 500;
        public const int DefaultPage = 1;

        //Employee
        public const string NOT_FOUND_EMPLOYEE = "Không tìm thấy nhân viên phù hợp với thông tin";
        public const string SUC_UPDATE_EMPLOYEE = "Cập nhật tài khoản thành công!";
        public const string FAILED_UPDATE_EMPLOYEE = "Cập nhật thông tin nhân viên thành công!";
        public const string SUC_CREATE_EMPLOYEE = "Tạo nhân viên mới thành công!";
        public const string FAILED_CREATE_EMPLOYEE = "Tạo nhân viên mới thất bại!";
        public const string SUC_DELETE_EMPLOYEE = "Xóa nhân viên thành công!";
        public const string FAILED_DELETE_EMPLOYEE = "Xóa nhân viên thất bại!";
        public const string EXISTED_EMPLOYEE = "Nhân viên đã tồn tại!";

        //Benefit
        public const string NOT_FOUND_BENEFIT = "Không tìm thấy phúc lợi với thông tin tương ứng!";
        public const string SUC_UPDATE_BENEFIT = "Cập nhật thông tin phúc lợi thành công!";
        public const string FAILED_UDPATE_BENEFIT = "Cập nhật thông tin phúc lợi mới thất bại rồi!";
        public const string SUC_CREATE_BENEFIT = "Tạo phúc lợi mới thành công!";
        public const string FAILED_CREATE_BENEFIT = "Tạo phúc lợi mới thất bại!";
        public const string SUC_DELETE_BENEFIT = "Xóa thông tin phúc lợi thành công!";
        public const string FAILED_DELETE_BENEFIT = "Xóa thông tin phúc lợi thất bại!";
        public const string EXISTED_BENEFIT = "Tồn tại phúc lợi!";
        //Allowance
        public const string NOT_FOUND_ALLOWANCE = "Không tìm thấy trợ cấp với thông tin tương ứng!";
        public const string SUC_UPDATE_ALLOWANCE = "Cập nhật thông tin trợ cấp thành công!";
        public const string FAILED_UDPATE_ALLOWANCE = "Cập nhật thông tin trợ cấp mới thất bại rồi!";
        public const string SUC_CREATE_ALLOWANCE = "Tạo trợ cấp mới thành công!";
        public const string FAILED_CREATE_ALLOWANCE = "Tạo trợ cấp mới thất bại!";
        public const string SUC_DELETE_ALLOWANCE = "Xóa thông tin trợ cấp thành công!";
        public const string FAILED_DELETE_ALLOWANCE = "Xóa thông tin trợ cấp thất bại!";
        public const string EXISTED_ALLOWANCE = "Tồn tại trợ cấp!";
        //achievement
        public const string NOT_FOUND_ACHIEVEMENT = "Không tìm thấy thành tựu với thông tin tương ứng!";
        public const string SUC_UPDATE_ACHIEVEMENT = "Cập nhật thông tin thành tựu thành công!";
        public const string FAILED_UDPATE_ACHIEVEMENT = "Cập nhật thông tin thành tựu mới thất bại rồi!";
        public const string SUC_CREATE_ACHIEVEMENT = "Tạo thành tựu mới thành công!";
        public const string FAILED_CREATE_ACHIEVEMENT = "Tạo thành tựu mới thất bại!";
        public const string SUC_DELETE_ACHIEVEMENT = "Xóa thông tin thành tựu thành công!";
        public const string FAILED_DELETE_ACHIEVEMENT = "Xóa thông tin thành tựu thất bại!";
        public const string EXISTED_ACHIEVEMENT = "Tồn tại thành tựu!";
        //Attendance
        public const string NOT_FOUND_ATTENDANCE = "Không tìm thấy thông tin chấm công tương ứng!";
        public const string SUC_UPDATE_ATTENDANCE = "Cập nhật thông tin chấm công thành công!";
        public const string FAILED_UDPATE_ATTENDANCE = "Cập nhật thông tin chấm công mới thất bại rồi!";
        public const string SUC_CREATE_ATTENDANCE = "Tạo chấm công mới thành công!";
        public const string FAILED_CREATE_ATTENDANCE = "Tạo thông tin chấm công mới thất bại!";
        public const string SUC_DELETE_ATTENDANCE = "Xóa thông tin chấm công thành công!";
        public const string FAILED_DELETE_ATTENDANCE = "Xóa thông tin chấm công thất bại!";
        public const string EXISTED_ATTENDANCE = "Bạn đã chấm công rồi!";

    }
}
//srvrast