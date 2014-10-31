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
    public class SiteAppUserController : Controller
    {
        private dukeofaustinEntities db = new dukeofaustinEntities();

        //
        // GET: /SiteAppUser/

        public ActionResult Index()
        {
            return View(db.SiteAppUsers.ToList());
        }

        //
        // GET: /SiteAppUser/Details/5

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
        // GET: /SiteAppUser/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SiteAppUser/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SiteAppUser siteappuser)
        {
            if (ModelState.IsValid)
            {
                db.SiteAppUsers.Add(siteappuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteappuser);
        }

        //
        // GET: /SiteAppUser/Edit/5

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
        // POST: /SiteAppUser/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SiteAppUser siteappuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siteappuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siteappuser);
        }

        //
        // GET: /SiteAppUser/Delete/5

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
        // POST: /SiteAppUser/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteAppUser siteappuser = db.SiteAppUsers.Find(id);
            db.SiteAppUsers.Remove(siteappuser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}