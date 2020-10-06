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
        public IEnumerable<UserViewModel> Users { get; set; }

        public MainPageViewModels()
        {
            Doctors = new List<Doctor>();
            Specializations = new List<Specialization>();
            Users = new List<UserViewModel>();
        }
    }
}