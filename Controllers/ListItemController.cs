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
    public class ListItemController : Controller
    {
        private dukeofaustinEntities db = new dukeofaustinEntities();

        //
        // GET: /ListItem/

        public ActionResult Index()
        {
            var lsttbl_item = db.lsttbl_Item.Include(l => l.lsttbl_Group);
            return View(lsttbl_item.ToList());
        }

        //
        // GET: /ListItem/Details/5

        public ActionResult Details(int id = 0)
        {
            lsttbl_Item lsttbl_item = db.lsttbl_Item.Find(id);
            if (lsttbl_item == null)
            {
                return HttpNotFound();
            }
            return View(lsttbl_item);
        }

        //
        // GET: /ListItem/Create

        public ActionResult Create()
        {
            ViewBag.GrpId = new SelectList(db.lsttbl_Group, "GrpId", "Descrip");
            return View();
        }

        //
        // POST: /ListItem/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(lsttbl_Item lsttbl_item)
        {
            if (ModelState.IsValid)
            {
                db.lsttbl_Item.Add(lsttbl_item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GrpId = new SelectList(db.lsttbl_Group, "GrpId", "Descrip", lsttbl_item.GrpId);
            return View(lsttbl_item);
        }

        //
        // GET: /ListItem/Edit/5

        public ActionResult Edit(int id = 0)
        {
            lsttbl_Item lsttbl_item = db.lsttbl_Item.Find(id);
            if (lsttbl_item == null)
            {
                return HttpNotFound();
            }
            ViewBag.GrpId = new SelectList(db.lsttbl_Group, "GrpId", "Descrip", lsttbl_item.GrpId);
            return View(lsttbl_item);
        }

        //
        // POST: /ListItem/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(lsttbl_Item lsttbl_item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lsttbl_item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GrpId = new SelectList(db.lsttbl_Group, "GrpId", "Descrip", lsttbl_item.GrpId);
            return View(lsttbl_item);
        }

        //
        // GET: /ListItem/Delete/5

        public ActionResult Delete(int id = 0)
        {
            lsttbl_Item lsttbl_item = db.lsttbl_Item.Find(id);
            if (lsttbl_item == null)
            {
                return HttpNotFound();
            }
            return View(lsttbl_item);
        }

        //
        // POST: /ListItem/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lsttbl_Item lsttbl_item = db.lsttbl_Item.Find(id);
            db.lsttbl_Item.Remove(lsttbl_item);
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