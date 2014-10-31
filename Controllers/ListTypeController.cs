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
    public class ListTypeController : Controller
    {
        private dukeofaustinEntities db = new dukeofaustinEntities();

        //
        // GET: /ListType/

        public ActionResult Index()
        {
            return View(db.lsttbl_Type.ToList());
        }

        //
        // GET: /ListType/Details/5

        public ActionResult Details(int id = 0)
        {
            lsttbl_Type lsttbl_type = db.lsttbl_Type.Find(id);
            if (lsttbl_type == null)
            {
                return HttpNotFound();
            }
            return View(lsttbl_type);
        }

        //
        // GET: /ListType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ListType/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(lsttbl_Type lsttbl_type)
        {
            if (ModelState.IsValid)
            {
                db.lsttbl_Type.Add(lsttbl_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lsttbl_type);
        }

        //
        // GET: /ListType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            lsttbl_Type lsttbl_type = db.lsttbl_Type.Find(id);
            if (lsttbl_type == null)
            {
                return HttpNotFound();
            }
            return View(lsttbl_type);
        }

        //
        // POST: /ListType/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(lsttbl_Type lsttbl_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lsttbl_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lsttbl_type);
        }

        //
        // GET: /ListType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            lsttbl_Type lsttbl_type = db.lsttbl_Type.Find(id);
            if (lsttbl_type == null)
            {
                return HttpNotFound();
            }
            return View(lsttbl_type);
        }

        //
        // POST: /ListType/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lsttbl_Type lsttbl_type = db.lsttbl_Type.Find(id);
            db.lsttbl_Type.Remove(lsttbl_type);
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