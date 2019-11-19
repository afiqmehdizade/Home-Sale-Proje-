using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FinalProj.Data;
using static FinalProj.FileExtensions.FileExtensions;


namespace FinalProj.Areas.Admin.Controllers
{[isAdmin]
    public class AJAXController : Controller
    {
        readonly FinalProjContext _context;
        public AJAXController()
        {
            _context = new FinalProjContext();
        }
        // GET: Admin/AJAX
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Admindelete(int? deleteadv)
        {
            if (deleteadv == null)
            {
                return Json(new { status = "400" }, JsonRequestBehavior.AllowGet);
            };
            var dbdel = _context.Adverts.Find(deleteadv);

            if (dbdel == null)
            {
                return Json(new { status = "400" }, JsonRequestBehavior.AllowGet);
            };
            DeleteImage("~/Images", dbdel.Image);
            _context.Adverts.Remove(dbdel);
            await _context.SaveChangesAsync();
            return Json(new { status = "200", data = Url.Action("Index", "Adverts") }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Adminsrc(string keyword)
        {
            var dblist = _context.Users.Where(m => m.Firstname.Contains(keyword) || m.Lastname.Contains(keyword)).ToList();
            return PartialView("_adminSearch", dblist);
        }

        public ActionResult LoadMessages()
        {
            var dbmessage = _context.Messages.Where(m => m.isRead == false).OrderByDescending(m => m.CreatedAt).Take(5).ToList();

            return PartialView("_forMessage", dbmessage);
        }

        public async Task<ActionResult> Messagedelete(int deletemsg)
        {
            var dbmessage = _context.Messages.Find(deletemsg);
            _context.Messages.Remove(dbmessage);
            await _context.SaveChangesAsync();
            return Json(new { status = "200" }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Messageread(int readmsg)
        {
            var dbmessage = _context.Messages.Find(readmsg);
            dbmessage.isRead = true;
            await _context.SaveChangesAsync();
            return Json(new { status = "200" }, JsonRequestBehavior.AllowGet);
        }
    }
}