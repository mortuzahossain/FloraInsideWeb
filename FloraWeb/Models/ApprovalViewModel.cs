using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FloraWeb.Models
{
    public class ApprovalViewModel
    {
        public String UserId { get; set; }
        public List<UserViewModel> UserList { get; set; }
        public string Month { get; set; }
        public List<TourRegisterItem> tourRegisters { get; set; }

    }

    public class TourRegisterItem
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string By { get; set; }
        public string Fare { get; set; }
        public string Remarks { get; set; }
    }
}