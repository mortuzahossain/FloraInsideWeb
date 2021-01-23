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
                UserList = userResponse.ResponseData as List<UserViewModel>,
                tourRegisters = commonResponse.ResponseData as List<TourRegisterItem>
            };

            return View(approvalViewModel);
        }

        // GET: Approval/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Approval/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Approval/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Approval/Edit/5
        public ActionResult Edit(string id)
        {
            CommonResponse commonResponse = new ConvinceBillRepository().GetTourFromRegisterForApprovalById(id);
            return PartialView("_EditApprovalPartial", commonResponse.ResponseData as TourRegisterItem);
            //return PartialView("_EditApprovalPartial");
        }

        // POST: Approval/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, TourRegisterItem collection)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            //CommonResponse commonResponse = new ConvinceBillRepository().ApproveSingleTourInRegister(id,collection);

            return RedirectToAction("Index");

        }

        // GET: Approval/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Approval/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
