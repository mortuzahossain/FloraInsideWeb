using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExcelFileManager;
using FloraWeb.Entity;
using FloraWeb.Models;
using FloraWeb.Repository;

namespace FloraWeb.Controllers
{
    public class ClientDutyController : Controller
    {
        // GET: ClientDuty
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(ClientDutyViewModel clientDuty)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            string[] dates = clientDuty.DateRange.Split(Convert.ToChar("-"));
            string userId = Session["UserId"].ToString();
            string startDate = dates[0].Trim();
            string endDate = dates[1].Trim();

            CommonResponse commonResponse = new ConvinceBillRepository().GetTourFromRegisterByUserIdAndDateRange(userId, startDate, endDate);
            CommonResponse userProfileResponse = new UsersRepository().GetUserProfile(userId);
            UserProfile userProfile = (UserProfile) userProfileResponse.ResponseData;


            ExcelManager.ExportToExcel("Conv - "+ clientDuty.DateRange, (DataTable)commonResponse.ResponseData,new ReportParam()
            {
                Name = userProfile.Name,
                Department = userProfile.Department,
                Designation = userProfile.Designation,
                GenerationDate = DateTime.Today.ToString("dd/MM/yyyy")
            });

            return View();
        }

        
    }
}
