//using EmployeeManagement_BusinessLayer.IServices;
//using EmployeeManagement_BusinessLayer.Request.Account;
//using EmployeeManagement_BusinessLayer.Services;
//using EmployeeManagement_BusinessLayer.ViewModels;
//using EmployeeManagement_SWD392.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace EmployeeManagement.Controllers.Manager
//{
//    public class ManagerController : Controller
//    {
//        private IList<AccountViewModel> lstAccount;
//        private readonly IAccountService _service;
//        private AccountViewModel Account;
//       // private CreateAccountRequestModel createAccount;
//       // private UpdateAccountRequestModel updateAccount;
       

//        public ManagerController(IAccountService service)
//        {
//            _service = service;
//        }
//        // GET: ManagerController
//        public ActionResult Index()
//        {
//            lstAccount = _service.GetAccounts(0, 0).Results;
//            ViewBag.lstAccount = lstAccount;
//            return View("/Views/Account/Manager/Manager", lstAccount);

//        }

//        // GET: ManagerController/Details/5
//        public ActionResult Details(int? id)
//        {
//            if(id == null || _service == null)
//            {
//                return NotFound();  
//            }
//            var acc = _service.GetAccountByID(id.Value);
//            if (acc == null)
//            {
//                return NotFound();

//            }
//            else
//            {
//                Account = acc?.Value;
//            }
//            return View("/Views/Account/Manager/Manager", Account);
//        }

//        // GET: ManagerController/Create
//        public ActionResult Create()
//        {
//            //_service.CreateAccount(createAccount);
//            return View("/Views/Account/Manager/Manager");
//        }

//        // POST: ManagerController/Create // chua xong
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(CreateAccountRequestModel createAccount)
//        {
//            try
//            {
//                _service.CreateAccount(createAccount);
//                return View("/Views/Account/Manager/Manager", createAccount);
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: ManagerController/Edit/5
//        public ActionResult Edit(int id)
//        {
            
//            return View("/Views/Account/Manager/Manager");
//        }

//        // POST: ManagerController/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(UpdateAccountRequestModel updAccount)
//        {
           
//            try
//            {

//                //return RedirectToAction(nameof(Index));
//                _service.UpdateAccount(updAccount);
//                return View("/Views/Account/Manager/Manager");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: ManagerController/Delete/5
//        //public ActionResult Delete(int id)
//        //{
//        //    return View();
//        //}

//        // POST: ManagerController/Delete/5
//        [HttpDelete]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id)
//        {
//            try
//            {
//                _service.DeleteAccount(id);
//                return View("/Views/Account/Manager/Manager");
//                //return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
