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

    public class FleetAssetModelsController : Controller
    {
        private VehicleSetupEntities db = new VehicleSetupEntities();

        // GET: FleetAssetModels
        public ActionResult Index()
        {
            var fleetAssetModels = db.FleetAssetModels.Include(f => f.FleetAssetMake);
            return View(fleetAssetModels.ToList());
        }

        // GET: FleetAssetModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FleetAssetModel fleetAssetModel = db.FleetAssetModels.Find(id);
            if (fleetAssetModel == null)
            {
                return HttpNotFound();
            }
            return View(fleetAssetModel);
        }

        // GET: FleetAssetModels/Create
        public ActionResult Create()
        {
            ViewBag.FleetAssetMakeID = new SelectList(db.FleetAssetMakes, "ID", "Manufacturer");
            return View();
        }

        // POST: FleetAssetModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FleetAssetModel fleetAssetModel)
        {
            if (ModelState.IsValid)
            {
                db.FleetAssetModels.Add(fleetAssetModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FleetAssetMakeID = new SelectList(db.FleetAssetMakes, "ID", "Manufacturer", fleetAssetModel.FleetAssetMakeID);
            return View(fleetAssetModel);
        }

        // GET: FleetAssetModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FleetAssetModel fleetAssetModel = db.FleetAssetModels.Find(id);
            if (fleetAssetModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FleetAssetMakeID = new SelectList(db.FleetAssetMakes, "ID", "Manufacturer", fleetAssetModel.FleetAssetMakeID);
            return View(fleetAssetModel);
        }

        // POST: FleetAssetModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FleetAssetModel fleetAssetModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fleetAssetModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FleetAssetMakeID = new SelectList(db.FleetAssetMakes, "ID", "Manufacturer", fleetAssetModel.FleetAssetMakeID);
            return View(fleetAssetModel);
        }

        // GET: FleetAssetModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FleetAssetModel fleetAssetModel = db.FleetAssetModels.Find(id);
            if (fleetAssetModel == null)
            {
                return HttpNotFound();
            }
            return View(fleetAssetModel);
        }

        // POST: FleetAssetModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FleetAssetModel fleetAssetModel = db.FleetAssetModels.Find(id);
            db.FleetAssetModels.Remove(fleetAssetModel);
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
