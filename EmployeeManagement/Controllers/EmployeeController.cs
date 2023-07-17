using EmployeeManagement_BusinessLayer.Common;
using EmployeeManagement_BusinessLayer.IServices;
using EmployeeManagement_BusinessLayer.Request.Account;
using EmployeeManagement_BusinessLayer.Request.Employee;
using EmployeeManagement_BusinessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IList<EmployeeViewModel> lstEmployee;
        private readonly IEmployeeService _service;
        private EmployeeViewModel Employee;

        
        public EmployeeController(IEmployeeService service, ILogger<HomeController> logger)
        {
            _logger = logger;
            _service = service;
        }
        public ActionResult IndexPage()
        {
            return View("Index");
        }
        // GET: ManagerController
        public async Task<ActionResult> Index()
        {
            lstEmployee = _service.GetEmployees(0, Constraints.DefaultPaging).Results;
            ViewBag.lstEmployee = lstEmployee;
            return RedirectToAction("Index", "Benefit");

        }

        // GET: ManagerController/Details/5
        public ActionResult Details(string? id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }
            var emp = _service.GetEmployeeByCode(id);
            if (emp == null)
            {
                return NotFound();

            }
            else
            {
                Employee = emp?.Value;
            }
            return View("/Views/Account/Manager/Manager", Employee);
        }

        // GET: ManagerController/Create
        public ActionResult Create()
        {
            //_service.CreateAccount(createAccount);
            return View("/Views/Account/Manager/Manager");
        }

        // POST: ManagerController/Create // chua xong
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateEmployeeRequestModel createAccount)
        {
            try
            {
                createAccount = new CreateEmployeeRequestModel()
                {
                    EmployeeId = Request.Form["txt_empId"],
                    EmployeeName = Request.Form["txt_empName"],
                    Mail = Request.Form["txt_mail"],
                    EmployeeAddress = Request.Form["txt_empAddress"],
                    Phone = Request.Form["txt_phone"],
                    //DateOfHide, Birthdate
                    Coach = Request.Form["txt_coach"],
                    DepartmentId = Request.Form["txt_departmentId"],
                    Country = Request.Form["txt_country"],
                    BankAccount = Request.Form["txt_bankAccount"],
                    Status = 1,
                };
                string birthdate = Request.Form["txt_birthdate"];
                string dateOfHide = Request.Form["txt_dateOfHide"];
                int? age = null;
                if(birthdate != "")
                {
                    age = DateTime.Now.Year - DateTime.Parse(birthdate).Year;
                }
                if(birthdate == "")
                {
                    birthdate = null;
                }
                if(dateOfHide == "")
                {
                    dateOfHide = null;
                }
                if (createAccount.DepartmentId == "")
                {
                    createAccount.DepartmentId = null;
                }
                createAccount.Birthdate = DateTime.Parse(birthdate);
                createAccount.DateOfHide = DateTime.Parse(dateOfHide);
                createAccount.EmployeeAge = age;
                 await _service.CreateEmployee(createAccount);
                return View("Index", createAccount);
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerController/Edit/5
        public ActionResult Edit(int id)
        {

            return View("/Views/Account/Manager/Manager");
        }

        // POST: ManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateEmployeeRequestModel upEmp)
        {
            upEmp = new UpdateEmployeeRequestModel()
            {
                EmployeeId = Request.Form["txt_empId"],
                EmployeeName = Request.Form["txt_empName"],
                EmployeeAge = int.Parse(Request.Form["txt_empAge"]),
                Mail = Request.Form["txt_mail"],
                EmployeeAddress = Request.Form["txt_empAddress"],
                Phone = Request.Form["txt_phone"],
                
                
                Coach = Request.Form["txt_coach"],
                DepartmentId = Request.Form["txt_departmentId"],
                Country = Request.Form["txt_country"],
                Status = 1,
                BankAccount = Request.Form["txt_bankAccounT"],
            };
            String dateOfHide = Request.Form["txt_dateOfHide"];
            String birthDate = Request.Form["txt_birthdate"];
            if (dateOfHide != "")
            {
                upEmp.DateOfHide = DateTime.Parse(dateOfHide);
            }
            if(birthDate != "")
            {
                upEmp.Birthdate = DateTime.Parse(birthDate);
            }
            
            try
            {

                //return RedirectToAction(nameof(Index));
                await _service.UpdateEmployee(upEmp);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]


        //GET: ManagerController/Delete/5
        public ActionResult Delete(string? id)
        {
            try
            {
                _service.DeleteAccount(id);
                return RedirectToAction("../Index");
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
