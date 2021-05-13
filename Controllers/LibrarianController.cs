using LibraryMSMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMSMVC.Controllers
{
    public class LibrarianController : Controller
    {
        private Libraryentities adminDb = new Libraryentities();
        // GET: Librarian
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tblLibrarian user)
        {
            var adm = adminDb.tblLibrarians.SingleOrDefault(a => a.Email == user.Email && a.Password == user.Password);
            if (adm != null)
            {
                Session["userId"] = adm.LibrarianID;
                Session["userName"] = adm.LibrarianName;
                return RedirectToAction("LIndex", "TblBooks", new { userId = adm.LibrarianID, userName = adm.LibrarianName });
            }
            else if (user.Email == null && user.Password == null)
            {
                return View();
            }
            ViewBag.Message = "User name and password are not matching";
            return View();
        }
        [HandleError]
        public ActionResult Logout()
        {
            Session.Remove("LibrarianID");
            return RedirectToAction("Home", "Main");
        }
    }
}