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
    public class UsersController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["UserId"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        [ValidateAntiForgeryToken()]
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {

            var commonResponse = new UsersRepository().UsersLogin(loginViewModel);

            if (commonResponse.ResponseCode == Constants.ResponseCode.ResponseSuccess && commonResponse.ResponseData != null)
            {
                UserLogin users = (UserLogin)commonResponse.ResponseData;

                Session["UserId"] = users.UserId;
                Session["LoginId"] = users.LoginId;
                Session["LoginName"] = users.LoginName;
                Session["UserGroupName"] = users.UserGroupName;
                Session["UserGroupId"] = users.UserGroupId;
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Error = "Invalid Username or password.";
            }

            return View();
        }

    }
}
