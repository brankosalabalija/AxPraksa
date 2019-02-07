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
    public class UserListsController : Controller
    {
        private VehicleSetupEntities db = new VehicleSetupEntities();
        private ApplicationDbContext ap = new ApplicationDbContext();

        // GET: UserLists
        public ActionResult Index()
        {
            var userList = (from user in db.AspNetUsers
                            from uRole in user.AspNetRoles
                            join role in db.AspNetRoles on uRole.Id equals role.Id
                            select new UserList()
                            {
                                ID = user.Id,
                                Username = user.UserName,
                                Email = user.Email,
                                RoleName = role.Name,
                            });
            return View(userList.ToList());
        }

        // GET: UserLists/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserList userList = db.UserLists.Find(id);
            if (userList == null)
            {
                return HttpNotFound();
            }
            return View(userList);
        }

        // POST: UserLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var apUser = ap.Users.Find(id);
            var dbUser = db.AspNetUsers.Find(id);
            ap.Users.Remove(apUser);
            db.AspNetUsers.Remove(dbUser);
            ap.SaveChanges();
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
