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

            if (commonResponse.ResponseCode == Constants.ResponseCode.ResponseSuccess &&
                commonResponse.ResponseData != null) 
            {
                UserLogin users = (UserLogin)commonResponse.ResponseData;

                Session["UserId"] = users.UserId;
                Session["LoginId"] = users.LoginId;
                Session["LoginName"] = users.LoginName;
                Session["UserGroupName"] = users.UserGroupName;
                Session["UserGroupId"] = users.UserGroupId;
                TempData["SuccessMessage"] = "Login successful.";
                return RedirectToAction("Index", "Home");
            }

            TempData["ErrorMessage"] = "Invalid Username or password.";

            return View();
        }


        public ActionResult AddUser()
        {
            TempData["SuccessMessage"] = TempData["SuccessMessage"];
            var commonResponse = new UsersRepository().GetAllUserGroup();

            if (commonResponse.ResponseCode == Constants.ResponseCode.ResponseSuccess && commonResponse.ResponseData != null)
            {
                return View(new UserViewModel() { UserGroupList = (List<UserGroup>)commonResponse.ResponseData });
            }

            return View();
        }

        [ValidateAntiForgeryToken()]
        [HttpPost]
        public ActionResult AddUser(UserViewModel loginViewModel)
        {

            var commonResponse = new UsersRepository().AddUsers(loginViewModel);

            if (commonResponse.ResponseCode == Constants.ResponseCode.ResponseSuccess)
            {
                TempData["SuccessMessage"] = "User added successful.";
                return RedirectToAction("AddUser");
            }
            loginViewModel.UserGroupList = new UsersRepository().GetAllUserGroup().ResponseData as List<UserGroup>;
            TempData["ErrorMessage"] = "Failed to add user. Please try with new user id and email id.";
            return View(loginViewModel);
        }



    }
}
