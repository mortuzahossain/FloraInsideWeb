using FloraWeb.Entity;
using FloraWeb.Models;
using FloraWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FloraWeb.Controllers
{
    public class ApprovalController : Controller
    {
        // GET: Approval
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var commonResponse = new UsersRepository().GetAllUsers();
            ApprovalViewModel approvalViewModel = new ApprovalViewModel()
            {
                UserList = commonResponse.ResponseData as List<UserViewModel>
            };
            return View(approvalViewModel);
        }

        [HttpPost]
        public ActionResult Index(ApprovalViewModel approvalView)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            string[] Month = approvalView.Month.Split(Convert.ToChar("-"));
            CommonResponse commonResponse = new ConvinceBillRepository().GetTourFromRegisterForApprovalByUserIdAndMonth(approvalView.UserId, Month[1], Month[0]);
            var userResponse = new UsersRepository().GetAllUsers();
            ApprovalViewModel approvalViewModel = new ApprovalViewModel()
            {
                Month = approvalView.Month,
                UserList = userResponse.ResponseData as List<UserViewModel>,
                tourRegisters = commonResponse.ResponseData as List<TourRegisterItem>
            };

            return View(approvalViewModel);
        }

        // POST: Approval/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, string Amount,string Remarks)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            TourRegisterItem tourRegister = new TourRegisterItem()
            {
               
                Id = id,
                ApproveAmount = Amount,
                VerificationNote = Remarks
            };
            string approver = (string) Session["UserId"];
            CommonResponse commonResponse = new ConvinceBillRepository().ApproveSingleTourInRegister(approver, tourRegister);

            if(commonResponse.ResponseCode == Constants.ResponseCode.ResponseSuccess)
            {
                return Json("100");
            }

            return Json("0");

        }
        
        
        [HttpPost]
        public ActionResult ApproveAll(string UserId,string Month)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Users");
            }

            string[] month = Month.Split(Convert.ToChar("-"));
            CommonResponse commonResponse = new ConvinceBillRepository().ApproveAllTourInRegister((string)Session["UserId"], UserId, month[1], month[0]);

            if (commonResponse.ResponseCode == Constants.ResponseCode.ResponseSuccess)
            {
                return Json("100");
            }

            return Json("0");

        }
    }
}
