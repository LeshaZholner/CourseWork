﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.API.Models
{
    public class SpecializationCreateViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}