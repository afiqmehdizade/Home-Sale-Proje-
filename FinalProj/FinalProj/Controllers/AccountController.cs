using FinalProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using FinalProj.Data;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FinalProj.Controllers
{
    public class AccountController : Controller
    {
        FinalProjContext _context;
        public AccountController()
        {
            _context = new FinalProjContext();
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Login(string email, string password, bool? asAdmin = false)
        {
            if (string.IsNullOrEmpty(email.Trim()) || string.IsNullOrEmpty(password.Trim()))
            {
                ModelState.AddModelError("loginError", "Email və ya Parol Yanlışdır");
                return View();
            }

            try
            {
                MailAddress mailAddress = new MailAddress(email);
            }
            catch (Exception)
            {

                ModelState.AddModelError("loginError", "Duzgun Email Daxil Edin");
                return View();
            }
            
            var dbuser = _context.Users.FirstOrDefault(m => m.Email == email.Trim());

            if (dbuser == null)
            {
                ModelState.AddModelError("loginError", "Email və ya Parol Yanlışdır");
                return View();
            }

            if (!Crypto.VerifyHashedPassword(dbuser.Password, password.Trim()))
            {
                ModelState.AddModelError("loginError", "Email və ya Parol Yanlışdır");
                return View();
            }
            if (dbuser.Status== true)
            {
                dbuser.Status = false;
                await _context.SaveChangesAsync();
            }

            Session["lguser"] = dbuser;


            return RedirectToAction("Index", "Home");

          
        }

        public ActionResult Registration()
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Registration([Bind(Include = "Firstname,Lastname,Phone,Email,Password,ConfirmPassword,Status")]User user)
        {
            if (!ModelState.IsValid) return View(user);
            if (user.Phone.Length > 10)
            {
                ModelState.AddModelError("Phone", "Duzgun nomre daxil edin!");
                return View(user);
            }
            var unemail = _context.Users.FirstOrDefault(m => m.Email == user.Email);
            if (unemail!=null)
            {
                ModelState.AddModelError("Email", "Bu email artıq qeydiyyatdan keçib!");
                return View(user);
            }

            if (user.Password != user.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Şifrələr bir biri ilə uyğun deyil!");
                return View(user);
            }
            user.ConfirmPassword = user.Password = Crypto.HashPassword(user.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            Session["lguser"] = user;

            return RedirectToAction("Index","Home");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");

        }
    }
}