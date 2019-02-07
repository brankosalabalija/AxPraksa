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

    public class ComplienceTypesController : Controller
    {
        private VehicleSetupEntities db = new VehicleSetupEntities();

        // GET: ComplienceTypes
        public ActionResult Index()
        {
            return View(db.ComplienceTypes.ToList());
        }

        // GET: ComplienceTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplienceType complienceType = db.ComplienceTypes.Find(id);
            if (complienceType == null)
            {
                return HttpNotFound();
            }
            return View(complienceType);
        }

        // GET: ComplienceTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComplienceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComplienceType complienceType)
        {
            if (ModelState.IsValid)
            {
                db.ComplienceTypes.Add(complienceType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complienceType);
        }

        // GET: ComplienceTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplienceType complienceType = db.ComplienceTypes.Find(id);
            if (complienceType == null)
            {
                return HttpNotFound();
            }
            return View(complienceType);
        }

        // POST: ComplienceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ComplienceType complienceType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complienceType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(complienceType);
        }

        // GET: ComplienceTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplienceType complienceType = db.ComplienceTypes.Find(id);
            if (complienceType == null)
            {
                return HttpNotFound();
            }
            return View(complienceType);
        }

        // POST: ComplienceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComplienceType complienceType = db.ComplienceTypes.Find(id);
            db.ComplienceTypes.Remove(complienceType);
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
