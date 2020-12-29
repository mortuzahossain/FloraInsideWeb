using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FloraWeb.Models
{
    public class UserLogin
    {
        public string UserId { get; set; }
        public string LoginId { get; set; }
        public string LoginName { get; set; }
        public string UserGroupId { get; set; }
        public string UserGroupName { get; set; }
    }
}