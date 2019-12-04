using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
        private UserManager<ApplicationUser> _userManager;

        public HomeController()
        {
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        public ActionResult Index()
        {
            var model = new MainPageViewModels();
            if (User.Identity.IsAuthenticated)
            {
                var users = _userManager.Users.ToList();
                var usersView = new List<UserViewModel>();
                foreach (var user in users)
                {
                    var claims = _userManager.GetClaims(user.Id);
                    var userView = new UserViewModel();
                    userView.Id = user.Id;
                    userView.Email = user.Email;
                    userView.FirstName = claims.First(c => c.Type == "FirstName").Value;
                    userView.LastName = claims.First(c => c.Type == "LastName").Value;
                    userView.PhoneNumber = claims.First(c => c.Type == "Phonenumber").Value;
                    usersView.Add(userView);
                }
                model.Users = usersView;
                model.Doctors = db.Doctors;
                model.Specializations = db.Specializations;
            }
            return View(model);
        }

    }
}