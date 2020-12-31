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
    public class EmergencyController : Controller
    {
        // GET: Emergency
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var commonResponse = new EmergencyRepository().GetAllEmergencyContact();

            if (commonResponse.ResponseCode == Constants.ResponseCode.ResponseSuccess && commonResponse.ResponseData != null)
            {
                return View(commonResponse.ResponseData);
            }
            //else
            //{
            //    TempData["ErrorMessage"] = commonResponse.ResponseMsg;
            //}
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Create()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            return View();
        }


        [HttpPost]
        public ActionResult Create(EmergencyContactViewModel collection)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    var commonResponse = new EmergencyRepository().AddEmergencyContact(collection);

                    if (commonResponse.ResponseCode == Constants.ResponseCode.ResponseSuccess)
                    {
                        TempData["SuccessMessage"] = "Added successful.";
                        return View();
                    }

                }

                TempData["ErrorMessage"] = "Please try again.";
                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Emergency/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var commonResponse = new EmergencyRepository().GetEmergencyContact(id);
            EmergencyContactViewModel emergencyContact = null;
            if (commonResponse.ResponseCode == Constants.ResponseCode.ResponseSuccess &&
                    commonResponse.ResponseData != null)
            {
                emergencyContact = commonResponse.ResponseData as EmergencyContactViewModel;
            }
            return PartialView("_EditEmergencyPartial", emergencyContact);
        }

        // POST: Emergency/Edit/5
        [HttpPost]
        public ActionResult Edit(EmergencyContactViewModel emergencyContact)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            CommonResponse commonResponse = new EmergencyRepository().UpdateEmergencyContact(emergencyContact);

            if (commonResponse.ResponseCode == Constants.ResponseCode.ResponseSuccess)
            {
                TempData["SuccessMessage"] = commonResponse.ResponseMsg;
            }
            else
            {
                TempData["ErrorMessage"] = commonResponse.ResponseMsg;
            }
            return RedirectToAction("Index");
        }

        // GET: Emergency/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            return PartialView("_DeleteEmergencyPartial", new EmergencyContactViewModel() { Id = id});
        }

        // POST: Emergency/Delete/5
        [HttpPost]
        public ActionResult Delete(EmergencyContactViewModel emergencyContact)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            CommonResponse commonResponse = new EmergencyRepository().DeactieveEmergencyContact(emergencyContact);

            if (commonResponse.ResponseCode == Constants.ResponseCode.ResponseSuccess)
            {
                TempData["SuccessMessage"] = commonResponse.ResponseMsg;
            }
            else
            {
                TempData["ErrorMessage"] = commonResponse.ResponseMsg;
            }
            return RedirectToAction("Index");
        }
    }
}
