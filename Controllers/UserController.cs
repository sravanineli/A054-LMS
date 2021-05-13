using LibraryMSMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMSMVC.Controllers
{
    public class UserController : Controller
    {
        private Libraryentities userDb = new Libraryentities();
        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // Checks user credentials, redirecting to admin section (index, tblBooks). 
        [HttpPost]
        public ActionResult Login(tblUser user)
        {
            var adm = userDb.tblUsers.SingleOrDefault(a => a.UserEmail == user.UserEmail && a.UserPass == user.UserPass);
            if (adm != null)
            {
                Session["userId"] = adm.UserId;
                Session["userName"] = adm.UserName;
                return RedirectToAction("Index", "Borrow", new { userId = adm.UserId, userName = adm.UserName });
            }
            else if (user.UserEmail == null && user.UserPass == null)
            {
                return View();
            }
            ViewBag.Message = "User name and password are not matching";
            return View();
        }

        [HandleError]
        public ActionResult Logout()
        {
            Session.Remove("userId");
            return RedirectToAction("Home", "Main");
        }
        // GET: Register/Create
       
    }

}