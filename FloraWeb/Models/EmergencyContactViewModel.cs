﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FloraWeb.Models
{
    public class EmergencyContactViewModel
    {

        public string Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public string Descriptions { get; set; }
    }
}