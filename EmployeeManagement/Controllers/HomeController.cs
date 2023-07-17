using EmployeeManagement.Models;
using EmployeeManagement_BusinessLayer.Common;
using EmployeeManagement_BusinessLayer.IServices;
using EmployeeManagement_BusinessLayer.Request.Account;
using EmployeeManagement_BusinessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IManagerService _service;
        private AccountViewModel Account;
       // private CreateAccountRequestModel createAccount;
       // private UpdateAccountRequestModel updateAccount;
       

        public HomeController(IManagerService service, ILogger<HomeController> logger)
        {
            _logger = logger;   
            _service = service;
        }
        // GET: ManagerController
        public async Task<ActionResult> Index()
        {
           
            IList<AccountViewModel> lstAccount = _service.GetAccountService().GetAccounts(0, Constraints.DefaultPaging).Results;
            ViewBag.lstAccount = lstAccount;
            IList<BenefitViewModel> lstBef = _service.GetBenefitService().GetBenefits(0, Constraints.DefaultPaging).Results;
            ViewBag.bef = lstBef;
            IList<EmployeeViewModel> lstEmployee = _service.GetEmployeeService().GetEmployees(0, Constraints.DefaultPaging).Results;
            ViewBag.lstEmployee = lstEmployee;
            return View("../Index");

        }

        // GET: ManagerController/Details/5
        public ActionResult Details(int? id)
        {
            return View("/Views/Account/Manager/Manager", Account);
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
        public ActionResult Create(CreateAccountRequestModel createAccount)
        {
            try
            {
                return View("/Views/Account/Manager/Manager", createAccount);
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
        public async Task<ActionResult> Edit(UpdateAccountByManagerRequestModel updAccount)
         {

            try
            {

                //return RedirectToAction(nameof(Index));
                
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
        public ActionResult Delete(int id)
        {
            try
            {
                return RedirectToAction("Index");
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
    
}