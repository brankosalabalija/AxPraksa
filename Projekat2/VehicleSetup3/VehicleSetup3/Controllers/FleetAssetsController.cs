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
    public class FleetAssetsController : Controller
    {
        private VehicleSetupEntities db = new VehicleSetupEntities();

        // GET: FleetAssets
        public ActionResult Index()
        {
            var fleetAssets = db.FleetAssets.Include(f => f.AssetSubType).Include(f => f.AssetType).Include(f => f.FleetAssetMake).Include(f => f.FleetAssetModel).Include(f => f.FuelType);
            return View(fleetAssets.ToList());
        }

        // GET: FleetAssets/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FleetAsset fleetAsset = db.FleetAssets.Find(id);
            if (fleetAsset == null)
            {
                return HttpNotFound();
            }
            FABLists fabl = new FABLists()
            {
                fa = fleetAsset,
                cl = db.Compliences.Where(c => fleetAsset.FleetNo == c.FleetNo).ToList(),
                cp = db.Capacities.Where(v => fleetAsset.FleetNo == v.FleetNo).ToList(),
                af = db.AdditionalFields.Where(a => fleetAsset.FleetNo == a.FleetNo).ToList(),
                at = db.Attachments.Where(r => fleetAsset.FleetNo ==  r.FleetNo).ToList(),
            };
            return View(fabl);
        }

        // GET: FleetAssets/Create
        public ActionResult Create()
        {
            ViewBag.SubTypeID = new SelectList(db.AssetSubTypes, "ID", "SubType");
            ViewBag.TypeID = new SelectList(db.AssetTypes, "ID", "Type");
            ViewBag.FleetAssetMakeID = new SelectList(db.FleetAssetMakes, "ID", "Manufacturer");
            ViewBag.FleetAssetModelID = new SelectList(db.FleetAssetModels, "ID", "Name");
            ViewBag.FuelTypeID = new SelectList(db.FuelTypes, "ID", "Fuel");
            ViewBag.ComplienceSubTypeID = new SelectList(db.ComplienceSubTypes, "ID", "Name");
            ViewBag.ComplienceTypeID = new SelectList(db.ComplienceTypes, "ID", "Class");
            var fab = new FleetAssetBig();
            return View("Create5", fab);
        }
        public ActionResult Create0()
        {
            ViewBag.SubTypeID = new SelectList(db.AssetSubTypes, "ID", "SubType");
            ViewBag.TypeID = new SelectList(db.AssetTypes, "ID", "Type");
            ViewBag.FleetAssetMakeID = new SelectList(db.FleetAssetMakes, "ID", "Manufacturer");
            ViewBag.FleetAssetModelID = new SelectList(db.FleetAssetModels, "ID", "Name");
            ViewBag.FuelTypeID = new SelectList(db.FuelTypes, "ID", "Fuel");
            return View();
        }

        // POST: FleetAssets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create(FleetAsset fleetAsset)
        {
            if (ModelState.IsValid)
            {
                db.FleetAssets.Add(fleetAsset);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            ViewBag.SubTypeID = new SelectList(db.AssetSubTypes, "ID", "SubType", fleetAsset.SubTypeID);
            ViewBag.TypeID = new SelectList(db.AssetTypes, "ID", "Type", fleetAsset.TypeID);
            ViewBag.FleetAssetMakeID = new SelectList(db.FleetAssetMakes, "ID", "Manufacturer", fleetAsset.FleetAssetMakeID);
            ViewBag.FleetAssetModelID = new SelectList(db.FleetAssetModels, "ID", "Name", fleetAsset.FleetAssetModelID);
            ViewBag.FuelTypeID = new SelectList(db.FuelTypes, "ID", "Fuel", fleetAsset.FuelTypeID);
            return Json(fleetAsset);
        }

        // GET: FleetAssets/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FleetAsset fleetAsset = db.FleetAssets.Find(id);
            
            if (fleetAsset == null)
            {
                return HttpNotFound();
            }

            FABLists fabl = new FABLists()
            {
                fa = fleetAsset,
                cp = db.Capacities.Where(w => fleetAsset.FleetNo == w.FleetNo).ToList(),
                cl = db.Compliences.Where(v => fleetAsset.FleetNo == v.FleetNo).ToList(),
                af = db.AdditionalFields.Where(r => fleetAsset.FleetNo == r.FleetNo).ToList(),
                at = db.Attachments.Where(r => fleetAsset.FleetNo == r.FleetNo).ToList(),
            };

            ViewBag.SubTypeID = new SelectList(db.AssetSubTypes, "ID", "SubType", fleetAsset.SubTypeID);
            ViewBag.TypeID = new SelectList(db.AssetTypes, "ID", "Type", fleetAsset.TypeID);
            ViewBag.FleetAssetMakeID = new SelectList(db.FleetAssetMakes, "ID", "Manufacturer", fleetAsset.FleetAssetMakeID);
            ViewBag.FleetAssetModelID = new SelectList(db.FleetAssetModels, "ID", "Name", fleetAsset.FleetAssetModelID);
            ViewBag.FuelTypeID = new SelectList(db.FuelTypes, "ID", "Fuel", fleetAsset.FuelTypeID);
            //return View(fabl);
            return View("Edit0", fleetAsset);
        }

        // POST: FleetAssets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Edit(FleetAsset fleetAsset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fleetAsset).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            ViewBag.SubTypeID = new SelectList(db.AssetSubTypes, "ID", "SubType", fleetAsset.SubTypeID);
            ViewBag.TypeID = new SelectList(db.AssetTypes, "ID", "Type", fleetAsset.TypeID);
            ViewBag.FleetAssetMakeID = new SelectList(db.FleetAssetMakes, "ID", "Manufacturer", fleetAsset.FleetAssetMakeID);
            ViewBag.FleetAssetModelID = new SelectList(db.FleetAssetModels, "ID", "Name", fleetAsset.FleetAssetModelID);
            ViewBag.FuelTypeID = new SelectList(db.FuelTypes, "ID", "Fuel", fleetAsset.FuelTypeID);
            return Json(fleetAsset);
        }

        // GET: FleetAssets/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FleetAsset fleetAsset = db.FleetAssets.Find(id);
            if (fleetAsset == null)
            {
                return HttpNotFound();
            }
            return View(fleetAsset);
        }

        // POST: FleetAssets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FleetAsset fleetAsset = db.FleetAssets.Find(id);
            List<Complience> complFA = db.Compliences.Where(c => fleetAsset.FleetNo == c.FleetNo).ToList();
            List<AdditionalField> addfFA = db.AdditionalFields.Where(a => fleetAsset.FleetNo == a.FleetNo).ToList();
            List<Capacity> capalFA = db.Capacities.Where(v => fleetAsset.FleetNo == v.FleetNo).ToList();
            List<Attachment> attaFA = db.Attachments.Where(g => fleetAsset.FleetNo == g.FleetNo).ToList();
            //delete capacities with this FANo
            foreach (Capacity cap in capalFA)
                db.Capacities.Remove(cap);

            //delete compliences with this FANo
            foreach (Complience com in complFA)
                db.Compliences.Remove(com);

            //delete Additional Fields with this FANo
            foreach (AdditionalField ad in addfFA)
                db.AdditionalFields.Remove(ad);

            //delete Attachment Fields with this FANo
            foreach (Attachment at in attaFA)
                db.Attachments.Remove(at);
            //delete this FA
            db.FleetAssets.Remove(fleetAsset);
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
