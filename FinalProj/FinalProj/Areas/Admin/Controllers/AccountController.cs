using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProj.Data;
using FinalProj.Models;
using FinalProj.Areas.Admin.ViewModel;
using System.Web.Helpers;

namespace FinalProj.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        readonly FinalProjContext _context;
        public AccountController()
        {
            _context = new FinalProjContext();
        }
        // GET: Admin/Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(adminLogin adminLogin)
        {
            if (!ModelState.IsValid) return View(adminLogin);

            var dbadmin = _context.AdminSettings.FirstOrDefault(m => m.Email.Trim() == adminLogin.Email.Trim());

            if (dbadmin == null || !Crypto.VerifyHashedPassword(dbadmin.Password, adminLogin.Password))
            {
                ModelState.AddModelError("loginError", "Email və ya Parol Yanlışdır!");
                return View(adminLogin);
            }

            Session["lgadmin"] = dbadmin;

            return RedirectToAction("Index", "Dashboard");
        }


        public ActionResult Logout()
        {
            return View();
        }
    }
}