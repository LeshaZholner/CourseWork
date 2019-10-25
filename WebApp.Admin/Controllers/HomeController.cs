using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Admin.Models;

namespace WebApp.Admin.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var model = new MainPageViewModels();
            model.Users = db.Users;
            model.Doctors = db.Doctors;
            model.Specializations = db.Specializations;
            return View(model);
        }

    }
}