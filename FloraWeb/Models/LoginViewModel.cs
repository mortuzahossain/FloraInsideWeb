using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FloraWeb.Models
{
    public class LoginViewModel
    {
        [Required]
        public string LoginId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}