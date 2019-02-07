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

    [Authorize(Roles = "User,Admin")]
    public class AdditionalFieldsController : Controller
    {
        private VehicleSetupEntities db = new VehicleSetupEntities();

        // GET: AdditionalFields
        public ActionResult Index()
        {
            var additionalFields = db.AdditionalFields.Include(a => a.FleetAsset);
            return View(additionalFields.ToList());
        }

        // GET: AdditionalFields/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdditionalField additionalField = db.AdditionalFields.Find(id);
            if (additionalField == null)
            {
                return HttpNotFound();
            }
            return View(additionalField);
        }

        // GET: AdditionalFields/Create
        public ActionResult Create()
        {
            ViewBag.FleetNo = new SelectList(db.FleetAssets, "FleetNo", "RegistrationNo");
            return View();
        }

        // POST: AdditionalFields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create(AdditionalField additionalField)
        {
                if (ModelState.IsValid)
                {
                    db.AdditionalFields.Add(additionalField);
                    db.SaveChanges();
                    ViewBag.FleetNo = new SelectList(db.FleetAssets, "FleetNo", "RegistrationNo", additionalField.FleetNo);
                    //return Json("Index");
                }

            return Json(additionalField);
        }

        // GET: AdditionalFields/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdditionalField additionalField = db.AdditionalFields.Find(id);
            if (additionalField == null)
            {
                return HttpNotFound();
            }
            ViewBag.FleetNo = new SelectList(db.FleetAssets, "FleetNo", "FleetNo", additionalField.FleetNo);
            return View(additionalField);
        }

        // POST: AdditionalFields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Edit(AdditionalField additionalField)
        {
            if (ModelState.IsValid)
            {
                db.Entry(additionalField).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            ViewBag.FleetNo = new SelectList(db.FleetAssets, "FleetNo", "FleetNo", additionalField.FleetNo);
            // return View(additionalField);
            return Json(additionalField);
        }

        // GET: AdditionalFields/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdditionalField additionalField = db.AdditionalFields.Find(id);
            if (additionalField == null)
            {
                return HttpNotFound();
            }
            return View(additionalField);
        }

        // POST: AdditionalFields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdditionalField additionalField = db.AdditionalFields.Find(id);
            db.AdditionalFields.Remove(additionalField);
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
