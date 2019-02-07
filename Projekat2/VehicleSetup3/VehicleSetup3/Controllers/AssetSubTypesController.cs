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
    public class AssetSubTypesController : Controller
    {
        private VehicleSetupEntities db = new VehicleSetupEntities();

        // GET: AssetSubTypes
        public ActionResult Index()
        {
            var assetSubTypes = db.AssetSubTypes.Include(a => a.AssetType);
            return View(assetSubTypes.ToList());
        }

        // GET: AssetSubTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetSubType assetSubType = db.AssetSubTypes.Find(id);
            if (assetSubType == null)
            {
                return HttpNotFound();
            }
            return View(assetSubType);
        }

        // GET: AssetSubTypes/Create
        public ActionResult Create()
        {
            ViewBag.AssetTypeID = new SelectList(db.AssetTypes, "ID", "Type");
            return View();
        }

        // POST: AssetSubTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssetSubType assetSubType)
        {
            if (ModelState.IsValid)
            {
                db.AssetSubTypes.Add(assetSubType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssetTypeID = new SelectList(db.AssetTypes, "ID", "Type", assetSubType.AssetTypeID);
            return View(assetSubType);
        }

        // GET: AssetSubTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetSubType assetSubType = db.AssetSubTypes.Find(id);
            if (assetSubType == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetTypeID = new SelectList(db.AssetTypes, "ID", "Type", assetSubType.AssetTypeID);
            return View(assetSubType);
        }

        // POST: AssetSubTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AssetSubType assetSubType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assetSubType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssetTypeID = new SelectList(db.AssetTypes, "ID", "Type", assetSubType.AssetTypeID);
            return View(assetSubType);
        }

        // GET: AssetSubTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetSubType assetSubType = db.AssetSubTypes.Find(id);
            if (assetSubType == null)
            {
                return HttpNotFound();
            }
            return View(assetSubType);
        }

        // POST: AssetSubTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetSubType assetSubType = db.AssetSubTypes.Find(id);
            db.AssetSubTypes.Remove(assetSubType);
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
