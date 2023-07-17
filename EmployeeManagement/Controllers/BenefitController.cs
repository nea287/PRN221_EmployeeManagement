using EmployeeManagement_BusinessLayer.Common;
using EmployeeManagement_BusinessLayer.IServices;
using EmployeeManagement_BusinessLayer.Request.Benefit;
using EmployeeManagement_BusinessLayer.ViewModels;
using MessagePack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class BenefitController : Controller
    {
        private readonly IBenefitService _service;
        private readonly ILogger<BenefitController> _logger;

        public BenefitController(ILogger<BenefitController> logger,IBenefitService service)
        {
            _service = service;
            _logger = logger;
        }
        // GET: BenefitController
        public ActionResult Index()
        {
            IList<BenefitViewModel> bef = _service.GetBenefits(0, Constraints.DefaultPaging).Results;
            ViewBag.bef = bef;
            return View("Index");

        }

        // GET: BenefitController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BenefitController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BenefitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BenefitRequestModel model)
        {
            try
            {
                model = new BenefitRequestModel()
                {
                    EmployeeId = Request.Form["txt_empId"],
                    BenefitTypeId = int.Parse(Request.Form["txt_benefitTypeId"]),
                    Remarks = Request.Form["txt_remarks"],
                };
                string date = Request.Form["txt_receivedDate"];
                if(date != "")
                {
                    model.ReceivedDate = DateTime.Parse(date);
                }
                await _service.CreateBenefit(model);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: BenefitController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BenefitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateBenefitRequestModel model)
        {
            try
            {
                await _service.UpdateBenefit(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // POST: BenefitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                await _service.DeleteBenefit(id.Value);
                return RedirectToAction("../Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ManageResourse()
        {
            string action = Request.Form["action"];
            if(action == "Edit")
            {
                UpdateBenefitRequestModel model = new UpdateBenefitRequestModel()
                {
                    BenefitId = int.Parse(Request.Form["txt_benefitId"]),
                    EmployeeId = Request.Form["txt_empId"],
                    Remarks = Request.Form["txt_remarks"],
                    BenefitTypeId = int.Parse(Request.Form["txt_benefitTypeId"]),

                };
                string date = Request.Form["txt_receivedDate"]; 
                if(date != "")
                {
                    model.ReceivedDate = DateTime.Parse(date);
                }
                await Edit(model);
            }else if(action == "Delete")
            {
                int? id = int.Parse(Request.Form["txt_benefitId"]);
                await Delete(id.Value);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
