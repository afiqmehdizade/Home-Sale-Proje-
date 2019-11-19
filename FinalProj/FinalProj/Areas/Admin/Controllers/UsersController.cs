using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProj.Data;

namespace FinalProj.Areas.Admin.Controllers
{[isAdmin]
    public class UsersController : Controller
    {
        readonly FinalProjContext _context;
        public UsersController()
        {
            _context = new FinalProjContext();
        }
        // GET: Admin/Users
        public ActionResult Index()
        {
            return View(_context.Users.ToList());
        }

        public ActionResult useradv (int id)
        {
            return View(_context.Adverts.Where(m=>m.UserId == id).ToList());
        }
    }
}