using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProj.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {[isAdmin]
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            var admin = Session["lgadmin"] as FinalProj.Models.adminSetting;
            return View(admin);
        }
    }
}