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

    public class ComplienceSubTypesController : Controller
    {
        private VehicleSetupEntities db = new VehicleSetupEntities();

        // GET: ComplienceSubTypes
        public ActionResult Index()
        {
            return View(db.ComplienceSubTypes.ToList());
        }

        // GET: ComplienceSubTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplienceSubType complienceSubType = db.ComplienceSubTypes.Find(id);
            if (complienceSubType == null)
            {
                return HttpNotFound();
            }
            return View(complienceSubType);
        }

        // GET: ComplienceSubTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComplienceSubTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComplienceSubType complienceSubType)
        {
            if (ModelState.IsValid)
            {
                db.ComplienceSubTypes.Add(complienceSubType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complienceSubType);
        }

        // GET: ComplienceSubTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplienceSubType complienceSubType = db.ComplienceSubTypes.Find(id);
            if (complienceSubType == null)
            {
                return HttpNotFound();
            }
            return View(complienceSubType);
        }

        // POST: ComplienceSubTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ComplienceSubType complienceSubType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complienceSubType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(complienceSubType);
        }

        // GET: ComplienceSubTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplienceSubType complienceSubType = db.ComplienceSubTypes.Find(id);
            if (complienceSubType == null)
            {
                return HttpNotFound();
            }
            return View(complienceSubType);
        }

        // POST: ComplienceSubTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComplienceSubType complienceSubType = db.ComplienceSubTypes.Find(id);
            db.ComplienceSubTypes.Remove(complienceSubType);
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
