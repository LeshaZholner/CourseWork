using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Admin.Models.Doctors;
using WebApp.Admin.Models.Specializations;

namespace WebApp.Admin.Models
{
    public class MainPageViewModels
    {
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Specialization> Specializations { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}