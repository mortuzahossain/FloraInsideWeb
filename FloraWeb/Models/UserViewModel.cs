using FloraWeb.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FloraWeb.Models
{
    public class UserViewModel
    {
        [Required]
        public string LoginId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string LoginName { get; set; }
        public List<UserGroup> UserGroupList { get; set; }
        [Required]
        public string UserGroupId { get; set; }
    }
}