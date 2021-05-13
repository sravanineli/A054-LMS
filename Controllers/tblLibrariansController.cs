using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryMSMVC.Models;

namespace LibraryMSMVC.Controllers
{
    public class tblLibrariansController : Controller
    {
        private Libraryentities db = new Libraryentities();

        // GET: tblLibrarians
        public ActionResult Index()
        {
            return View(db.tblLibrarians.ToList());
        }
        public ActionResult GetAll()
        {
            var userlist = db.tblLibrarians.ToList();
            return Json(new { data = userlist }, JsonRequestBehavior.AllowGet);
        }

        // GET: tblLibrarians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLibrarian tblLibrarian = db.tblLibrarians.Find(id);
            if (tblLibrarian == null)
            {
                return HttpNotFound();
            }
            return View(tblLibrarian);
        }

        // GET: tblLibrarians/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblLibrarians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LibrarianID,LibrarianName,Email,Password")] tblLibrarian tblLibrarian)
        {
            if (ModelState.IsValid)
            {
                db.tblLibrarians.Add(tblLibrarian);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblLibrarian);
        }

        // GET: tblLibrarians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLibrarian tblLibrarian = db.tblLibrarians.Find(id);
            if (tblLibrarian == null)
            {
                return HttpNotFound();
            }
            return View(tblLibrarian);
        }

        // POST: tblLibrarians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LibrarianID,LibrarianName,Email,Password")] tblLibrarian tblLibrarian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblLibrarian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblLibrarian);
        }

        // GET: tblLibrarians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLibrarian tblLibrarian = db.tblLibrarians.Find(id);
            if (tblLibrarian == null)
            {
                return HttpNotFound();
            }
            return View(tblLibrarian);
        }

        // POST: tblLibrarians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblLibrarian tblLibrarian = db.tblLibrarians.Find(id);
            db.tblLibrarians.Remove(tblLibrarian);
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
