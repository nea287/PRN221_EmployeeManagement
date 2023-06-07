using System;
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

    }
}
