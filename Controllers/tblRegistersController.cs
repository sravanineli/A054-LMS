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
    public class tblRegistersController : Controller
    {
        private Libraryentities db = new Libraryentities();

        // GET: tblRegisters
        public ActionResult Index()
        {
            return View(db.tblRegisters.ToList());
        }

        // GET: tblRegisters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRegister tblRegister = db.tblRegisters.Find(id);
            if (tblRegister == null)
            {
                return HttpNotFound();
            }
            return View(tblRegister);
        }

        // GET: tblRegisters/Create
        public ActionResult Create()
        {
          ViewBag.category = new SelectList(new[] { "User", "Librarian" });
            ViewBag.select = new SelectList(new[] { "Male", "Female" });
            return View();
        }

        // POST: tblRegisters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,FirstName,LastName,DOB,Gender,Contact,Email,Password,Category")] tblRegister tblRegister)
        {
            if (ModelState.IsValid)
            {
                db.tblRegisters.Add(tblRegister);
                db.SaveChanges();
                return RedirectToAction("Login","Main");
            }

            return View(tblRegister);
        }

        // GET: tblRegisters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRegister tblRegister = db.tblRegisters.Find(id);
            if (tblRegister == null)
            {
                return HttpNotFound();
            }
            return View(tblRegister);
        }

        // POST: tblRegisters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FirstName,LastName,DOB,Gender,Contact,Email,Password,Category")] tblRegister tblRegister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblRegister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblRegister);
        }

        // GET: tblRegisters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRegister tblRegister = db.tblRegisters.Find(id);
            if (tblRegister == null)
            {
                return HttpNotFound();
            }
            return View(tblRegister);
        }

        // POST: tblRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblRegister tblRegister = db.tblRegisters.Find(id);
            db.tblRegisters.Remove(tblRegister);
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
