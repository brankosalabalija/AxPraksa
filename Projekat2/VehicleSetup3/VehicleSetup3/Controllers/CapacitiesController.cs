using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VehicleSetup3.Models;

namespace VehicleSetup3.Controllers
{
    public class CapacitiesController : Controller
    {
        private VehicleSetupEntities db = new VehicleSetupEntities();

        // GET: Capacities
        [Authorize (Roles = "Admin")]

        public ActionResult Index()
        {
            var capacities = db.Capacities.Include(c => c.FleetAsset);
            return View(capacities.ToList());
        }

        // GET: Capacities/Details/5
        [Authorize (Roles = "Admin")]

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capacity capacity = db.Capacities.Find(id);
            if (capacity == null)
            {
                return HttpNotFound();
            }
            return View(capacity);
        }

        // GET: Capacities/Create
        public ActionResult Create()
        {
            ViewBag.FleetNo = new SelectList(db.FleetAssets, "FleetNo", "RegistrationNo");
            return View();
        }

        // POST: Capacities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create(Capacity capacity)
        {
            if (ModelState.IsValid)
            {
                db.Capacities.Add(capacity);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            ViewBag.FleetNo = new SelectList(db.FleetAssets, "FleetNo", "RegistrationNo", capacity.FleetNo);
            return Json(capacity);
        }

        // GET: Capacities/Edit/5
        [Authorize (Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capacity capacity = db.Capacities.Find(id);
            if (capacity == null)
            {
                return HttpNotFound();
            }
            ViewBag.FleetNo = new SelectList(db.FleetAssets, "FleetNo", "RegistrationNo", capacity.FleetNo);
            return View(capacity);
        }

        // POST: Capacities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Edit(Capacity capacity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(capacity).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            ViewBag.FleetNo = new SelectList(db.FleetAssets, "FleetNo", "RegistrationNo", capacity.FleetNo);
            return Json(capacity);
        }

        // GET: Capacities/Delete/5
        [Authorize (Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capacity capacity = db.Capacities.Find(id);
            if (capacity == null)
            {
                return HttpNotFound();
            }
            return View(capacity);
        }

        // POST: Capacities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize (Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Capacity capacity = db.Capacities.Find(id);
            db.Capacities.Remove(capacity);
            db.SaveChanges();
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
