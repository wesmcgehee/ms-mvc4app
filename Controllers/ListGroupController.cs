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
    public class ListGroupController : Controller
    {
        private dukeofaustinEntities db = new dukeofaustinEntities();

        //
        // GET: /ListGroup/

        public ActionResult Index()
        {
            var lsttbl_group = db.lsttbl_Group.Include(l => l.lsttbl_Type);
            return View(lsttbl_group.ToList());
        }

        //
        // GET: /ListGroup/Details/5

        public ActionResult Details(int id = 0)
        {
            lsttbl_Group lsttbl_group = db.lsttbl_Group.Find(id);
            if (lsttbl_group == null)
            {
                return HttpNotFound();
            }
            return View(lsttbl_group);
        }

        //
        // GET: /ListGroup/Create

        public ActionResult Create()
        {
            ViewBag.TypeId = new SelectList(db.lsttbl_Type, "TypeId", "Descrip");
            return View();
        }

        //
        // POST: /ListGroup/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(lsttbl_Group lsttbl_group)
        {
            if (ModelState.IsValid)
            {
                db.lsttbl_Group.Add(lsttbl_group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypeId = new SelectList(db.lsttbl_Type, "TypeId", "Descrip", lsttbl_group.TypeId);
            return View(lsttbl_group);
        }

        //
        // GET: /ListGroup/Edit/5

        public ActionResult Edit(int id = 0)
        {
            lsttbl_Group lsttbl_group = db.lsttbl_Group.Find(id);
            if (lsttbl_group == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeId = new SelectList(db.lsttbl_Type, "TypeId", "Descrip", lsttbl_group.TypeId);
            return View(lsttbl_group);
        }

        //
        // POST: /ListGroup/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(lsttbl_Group lsttbl_group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lsttbl_group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeId = new SelectList(db.lsttbl_Type, "TypeId", "Descrip", lsttbl_group.TypeId);
            return View(lsttbl_group);
        }

        //
        // GET: /ListGroup/Delete/5

        public ActionResult Delete(int id = 0)
        {
            lsttbl_Group lsttbl_group = db.lsttbl_Group.Find(id);
            if (lsttbl_group == null)
            {
                return HttpNotFound();
            }
            return View(lsttbl_group);
        }

        //
        // POST: /ListGroup/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lsttbl_Group lsttbl_group = db.lsttbl_Group.Find(id);
            db.lsttbl_Group.Remove(lsttbl_group);
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