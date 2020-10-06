using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Admin.Models;

namespace WebApp.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class DoctorAvailabilitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DoctorAvailabilities
        [OverrideAuthorization]
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var doctorAccessibilities = db.DoctorAccessibilities.Include(d => d.Doctor);
            return View(await doctorAccessibilities.ToListAsync());
        }

        // GET: DoctorAvailabilities/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorAvailability doctorAvailability = await db.DoctorAccessibilities.FindAsync(id);
            if (doctorAvailability == null)
            {
                return HttpNotFound();
            }
            return View(doctorAvailability);
        }

        // GET: DoctorAvailabilities/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "FirstName");
            return View();
        }

        // POST: DoctorAvailabilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DoctorId,DateAvailability,TimeFrom,TimeTo")] DoctorAvailability doctorAvailability)
        {
            if (ModelState.IsValid)
            {
                db.DoctorAccessibilities.Add(doctorAvailability);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "FirstName", doctorAvailability.DoctorId);
            return View(doctorAvailability);
        }

        // GET: DoctorAvailabilities/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorAvailability doctorAvailability = await db.DoctorAccessibilities.FindAsync(id);
            if (doctorAvailability == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "FirstName", doctorAvailability.DoctorId);
            return View(doctorAvailability);
        }

        // POST: DoctorAvailabilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DoctorId,DateAvailability,TimeFrom,TimeTo")] DoctorAvailability doctorAvailability)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorAvailability).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "FirstName", doctorAvailability.DoctorId);
            return View(doctorAvailability);
        }

        // GET: DoctorAvailabilities/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorAvailability doctorAvailability = await db.DoctorAccessibilities.FindAsync(id);
            if (doctorAvailability == null)
            {
                return HttpNotFound();
            }
            return View(doctorAvailability);
        }

        // POST: DoctorAvailabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DoctorAvailability doctorAvailability = await db.DoctorAccessibilities.FindAsync(id);
            db.DoctorAccessibilities.Remove(doctorAvailability);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
