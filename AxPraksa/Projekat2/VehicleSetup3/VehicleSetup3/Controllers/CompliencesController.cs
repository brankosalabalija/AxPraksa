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
    public class CompliencesController : Controller
    {
        private VehicleSetupEntities db = new VehicleSetupEntities();

        // GET: Compliences
        [Authorize (Roles = "Admin")]
        public ActionResult Index()
        {
            var compliences = db.Compliences.Include(c => c.ComplienceSubType).Include(c => c.ComplienceType).Include(c => c.FleetAsset);
            return View(compliences.ToList());
        }

        [Authorize(Roles = "User,Admin")]
        public ActionResult ComplienceTypes()
        {
            var compliences = db.Compliences.Include(c => c.ComplienceSubType).Include(c => c.ComplienceType).Include(c => c.FleetAsset);
            return View(compliences.ToList());
        }
        // GET: Compliences/Details/5
        [Authorize (Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complience complience = db.Compliences.Find(id);
            if (complience == null)
            {
                return HttpNotFound();
            }
            return View(complience);
        }

        // GET: Compliences/Create
        public ActionResult Create()
        {
            ViewBag.SubTypeID = new SelectList(db.ComplienceSubTypes, "ID", "Name");
            ViewBag.ComplienceTypeID = new SelectList(db.ComplienceTypes, "ID", "Class");
            ViewBag.FleetNo = new SelectList(db.FleetAssets, "FleetNo", "FleetNo");
            return View();
        }

        // POST: Compliences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create( Complience complience)
        {
            if (ModelState.IsValid)
            {
                db.Compliences.Add(complience);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            ViewBag.TypeID = new SelectList(db.ComplienceSubTypes, "ID", "Name", complience.SubTypeID);
            ViewBag.ComplienceTypeID = new SelectList(db.ComplienceTypes, "ID", "Class", complience.ComplienceTypeID);
            ViewBag.FleetNo = new SelectList(db.FleetAssets, "FleetNo", "RegistrationNo", complience.FleetNo);
            return Json(complience);
        }

        // GET: Compliences/Edit/5
        [Authorize (Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complience complience = db.Compliences.Find(id);
            if (complience == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeID = new SelectList(db.ComplienceSubTypes, "ID", "Name", complience.SubTypeID);
            ViewBag.ComplienceTypeID = new SelectList(db.ComplienceTypes, "ID", "Class", complience.ComplienceTypeID);
            ViewBag.FleetNo = new SelectList(db.FleetAssets, "FleetNo", "RegistrationNo", complience.FleetNo);
            return View(complience);
        }

        // POST: Compliences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Edit(Complience complience)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complience).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            ViewBag.TypeID = new SelectList(db.ComplienceSubTypes, "ID", "Name", complience.SubTypeID);
            ViewBag.ComplienceTypeID = new SelectList(db.ComplienceTypes, "ID", "Class", complience.ComplienceTypeID);
            ViewBag.FleetNo = new SelectList(db.FleetAssets, "FleetNo", "RegistrationNo", complience.FleetNo);
            return Json(complience);
        }

        // GET: Compliences/Delete/5
        [Authorize (Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complience complience = db.Compliences.Find(id);
            if (complience == null)
            {
                return HttpNotFound();
            }
            return View(complience);
        }

        // POST: Compliences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize (Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Complience complience = db.Compliences.Find(id);
            db.Compliences.Remove(complience);
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
