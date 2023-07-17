using EmployeeManagement_BusinessLayer.Common;
using EmployeeManagement_BusinessLayer.IServices;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class LoginController : Controller
    {
        public IAccountService _service;
        public LoginController(IAccountService service)
        {
            _service = service;
        }

        public IActionResult Login()
        {
            string username = Request.Form["txt_username"];
            string password = Request.Form["txt_password"];
            var account = _service.Login(username, password);
            if (account.Result.Value.RoleCode.Value == (int)AccountRoleEnum.Manager)
            {
                return RedirectToAction("Index", "Manager");
            }
            else
            {
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
    }
}
