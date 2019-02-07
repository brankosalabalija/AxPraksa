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
    [Authorize(Roles = "Admin")]

    public class FleetAssetMakesController : Controller
    {
        private VehicleSetupEntities db = new VehicleSetupEntities();

        // GET: FleetAssetMakes
        public ActionResult Index()
        {
            return View(db.FleetAssetMakes.ToList());
        }

        // GET: FleetAssetMakes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FleetAssetMake fleetAssetMake = db.FleetAssetMakes.Find(id);
            if (fleetAssetMake == null)
            {
                return HttpNotFound();
            }
            return View(fleetAssetMake);
        }

        // GET: FleetAssetMakes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FleetAssetMakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FleetAssetMake fleetAssetMake)
        {
            if (ModelState.IsValid)
            {
                db.FleetAssetMakes.Add(fleetAssetMake);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fleetAssetMake);
        }

        // GET: FleetAssetMakes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FleetAssetMake fleetAssetMake = db.FleetAssetMakes.Find(id);
            if (fleetAssetMake == null)
            {
                return HttpNotFound();
            }
            return View(fleetAssetMake);
        }

        // POST: FleetAssetMakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FleetAssetMake fleetAssetMake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fleetAssetMake).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fleetAssetMake);
        }

        // GET: FleetAssetMakes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FleetAssetMake fleetAssetMake = db.FleetAssetMakes.Find(id);
            if (fleetAssetMake == null)
            {
                return HttpNotFound();
            }
            return View(fleetAssetMake);
        }

        // POST: FleetAssetMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FleetAssetMake fleetAssetMake = db.FleetAssetMakes.Find(id);
            db.FleetAssetMakes.Remove(fleetAssetMake);
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
