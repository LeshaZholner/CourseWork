﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApp.Admin.Models;

namespace WebApp.Admin.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();
        public UsersController()
        {
            //_userManager = userManager;
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        // GET: AspNetUsers
        public ActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        // GET: AspNetUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AspNetUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var user = new ApplicationUser()
                {
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                
                _userManager.Create(user, model.Password);
                _userManager.AddClaim(user.Id, new Claim("FirstName", model.FirstName));
                _userManager.AddClaim(user.Id, new Claim("LastName", model.LastName));
                _userManager.AddClaim(user.Id, new Claim("Phonenumber", model.PhoneNumber));
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: AspNetUsers/Edit/5
        public ActionResult Edit(string id)
        {
            var user = _userManager.FindById(id);
            if(user == null)
            {
                return HttpNotFound();
            }
            var claims = _userManager.GetClaims(user.Id);
            EditUserViewModel model = new EditUserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = claims.First(c => c.Type == "FirstName").Value,
                LastName = claims.First(c => c.Type == "LastName").Value,
                PhoneNumber = claims.First(c => c.Type == "Phonenumber").Value,
            };
            return View(model);
        }

        // POST: AspNetUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindById(model.Id);
                if(user != null)
                {
                    user.Email = model.Email;
                    user.PhoneNumber = model.PhoneNumber;
                }
                _userManager.Update(user);
                _userManager.AddClaim(user.Id, new Claim("FirstName", model.FirstName));
                _userManager.AddClaim(user.Id, new Claim("LastName", model.LastName));
                _userManager.AddClaim(user.Id, new Claim("Phonenumber", model.PhoneNumber));
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: AspNetUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aspNetUser = _userManager.FindById(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        } 

        // POST: AspNetUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var aspNetUser = _userManager.FindById(id);
            if(User != null)
            {
                _userManager.Delete(aspNetUser);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _userManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
