using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc4App.Models;

namespace Mvc4App.Controllers
{
    public class SiteUserController : Controller
    {
        private dukeofaustinEntities db = new dukeofaustinEntities();

        //
        // GET: /SiteUser/

        public ActionResult Index()
        {
            return View(db.SiteAppUsers.ToList());
        }

        //
        // GET: /SiteUser/Details/5

        public ActionResult Details(int id = 0)
        {
            SiteAppUser siteappuser = db.SiteAppUsers.Find(id);
            if (siteappuser == null)
            {
                return HttpNotFound();
            }
            return View(siteappuser);
        }

        //
        // GET: /SiteUser/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // GET: /SiteUser/Edit/5

        public ActionResult Show(int id = 0)
        {
            SiteAppUser siteappuser = db.SiteAppUsers.Find(id);
            return PartialView(siteappuser);
        }

        //
        // POST: /SiteUser/Edit/5

        [HttpPost]
        public ActionResult Show(SiteAppUser siteappuser)
        {
            if (ModelState.IsValid)
            {
                siteappuser.Audit = GetAuditString();
                db.Entry(siteappuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView(siteappuser);
        }
        //
        // POST: /SiteUser/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SiteAppUser siteappuser)
        {
            if (ModelState.IsValid)
            {
                siteappuser.Audit = GetAuditString("Ins-");
                db.SiteAppUsers.Add(siteappuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteappuser);
        }

        //
        // GET: /SiteUser/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SiteAppUser siteappuser = db.SiteAppUsers.Find(id);
            if (siteappuser == null)
            {
                return HttpNotFound();
            }
            return View(siteappuser);
        }

        //
        // POST: /SiteUser/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SiteAppUser siteappuser)
        {
            if (ModelState.IsValid)
            {
                siteappuser.Audit = GetAuditString();
                db.Entry(siteappuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siteappuser);
        }
  
        //
        // GET: /SiteUser/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SiteAppUser siteappuser = db.SiteAppUsers.Find(id);
            if (siteappuser == null)
            {
                return HttpNotFound();
            }
            return View(siteappuser);
        }

        //
        // POST: /SiteUser/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteAppUser siteappuser = db.SiteAppUsers.Find(id);
            db.SiteAppUsers.Remove(siteappuser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private string GetAuditString(string prefix = "Upd-")
        {
            DateTime now = DateTime.Now;
            var rtn = prefix + String.Format("{0:d/M/yyyy HH:mm:ss}", now);
            return rtn;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}