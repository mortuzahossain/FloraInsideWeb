using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FloraWeb.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login", "Users");
            //}

            //TempData["SuccessMessage"] = TempData["SuccessMessage"];

            return View();
        }
    }
}
