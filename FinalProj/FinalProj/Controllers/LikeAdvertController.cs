using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProj.Models;
using FinalProj.Data;
using System.Threading.Tasks;

namespace FinalProj.Controllers
{
    [Authorization]
    public class LikeAdvertController : Controller
    {
        readonly FinalProjContext _context;
        public LikeAdvertController()
        {
            _context = new FinalProjContext();
        }
        // GET: LikeAdvert
        public async Task<ActionResult>Index(int likeid)
        {
            var dbadvert = _context.Adverts.Find(likeid);
            if (dbadvert == null)
            {
                return Json(new { status = "400" }, JsonRequestBehavior.AllowGet);
            }
            User user = Session["lguser"] as User;

            var dblikedadv = _context.Likes.FirstOrDefault(m => m.AdvertId == likeid && m.UserId == user.Id);
            if (dblikedadv != null )
            {
                return Json(new { status = "400" }, JsonRequestBehavior.AllowGet);
            }

            _context.Likes.Add(new Like { UserId = user.Id, AdvertId = likeid });
            await _context.SaveChangesAsync();
            return Json(new { status = "200" }, JsonRequestBehavior.AllowGet);
        }

        public async Task< ActionResult> Dislike(int dislikeid)
        {
            var dbadvert = _context.Adverts.Find(dislikeid);

            if (dbadvert == null)
            {
                return Json(new { status = "400" }, JsonRequestBehavior.AllowGet);
            }
            User user = Session["lguser"] as User;
            var dblikedadv = _context.Likes.FirstOrDefault(m => m.AdvertId == dislikeid && m.UserId == user.Id);
            if (dblikedadv == null)
            {
                return Json(new { status = "400" }, JsonRequestBehavior.AllowGet);
            }

            _context.Likes.Remove(dblikedadv);
            await _context.SaveChangesAsync();


            return Json(new { status = "200", JsonRequestBehavior.AllowGet });
        }
    }
}