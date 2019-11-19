using FinalProj.Data;
using FinalProj.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FinalProj.Controllers
{
    [Authorization]
    public class UserController : Controller
    {
        FinalProjContext _context;
        public UserController()
        {
            _context = new FinalProjContext();
        }
        public ActionResult Index()
        {
            User user = Session["lguser"] as User;

            ViewBag.UserId = user.Id;
            ViewBag.TotalCount = _context.Adverts.Where(m => m.UserId == user.Id).Count();

            return View(_context.Adverts.Where(m => m.UserId == user.Id && m.User.Status == false).OrderByDescending(m => m.CreatedAt).Take(3).ToList());
        }


        public ActionResult Detail(int? id)
        {
            if (id == null) return HttpNotFound();
            var realuser = Session["lguser"] as User;
            var useradv = _context.Adverts.Find(id);
            if (useradv == null) return HttpNotFound();
            if (useradv.UserId != realuser.Id) return HttpNotFound();

            return View(useradv);
        }

        public ActionResult Privacy(int? id)
        {
            if (id == null) return HttpNotFound();

            var edituser = _context.Users.Find(id);

            if (edituser == null) return HttpNotFound();

            if (Session["lguser"] == null) return HttpNotFound();

            if (Session["lguser"] != null)
            {
                var user = Session["lguser"] as FinalProj.Models.User;
                if (id != user.Id) return HttpNotFound();

            }

            return View(edituser);
        }

        [HttpPost]
        public async Task<ActionResult> Privacy(string oldpass, string newpass, string confpass, string accblock)
        {
            if (oldpass != null && newpass != null && confpass != null && accblock != null) return HttpNotFound();

            var dbuser = Session["lguser"] as FinalProj.Models.User;
            var mainuser = _context.Users.Find(dbuser.Id);

            if (oldpass != null && newpass != null && confpass != null)
            {
                if (!Crypto.VerifyHashedPassword(dbuser.Password, oldpass))
                {
                    return Json(new { statuscode = "400", errormessage = "Kohnə parol duzgun deyil" }, JsonRequestBehavior.AllowGet);
                }

                if (newpass.Trim().Length <= 7)
                {
                    return Json(new { statuscode = "400", errormessage = "Parol ən az 8 sinvol olmalıdır!" }, JsonRequestBehavior.AllowGet);
                }
                if (newpass.Trim() != confpass.Trim())
                {
                    return Json(new { statuscode = "400", errormessage = "Yeni parolla təsdiq parolu uyğun deyil" }, JsonRequestBehavior.AllowGet);
                }

                mainuser.ConfirmPassword = mainuser.Password = Crypto.HashPassword(newpass);
                await _context.SaveChangesAsync();
                dbuser.ConfirmPassword = dbuser.Password = mainuser.Password;
                return Json(new { statuscode = "200", data = Url.Action("Index", "Home") }, JsonRequestBehavior.AllowGet);
            }

            if (oldpass != null || newpass != null || confpass != null) return HttpNotFound();

            if (accblock == null)
            {
                return Json(new { statuscode = "400", errormessage = "Parolu daxil edin!" }, JsonRequestBehavior.AllowGet);
            }

            if (!Crypto.VerifyHashedPassword(mainuser.Password, accblock))
            {
                return Json(new { statuscode = "400", errormessage = "Parolu Düzgün Deyil!" }, JsonRequestBehavior.AllowGet);
            }

            mainuser.Status = true;
            await _context.SaveChangesAsync();
            Session.Clear();

            return Json(new { statuscode = "200", data = Url.Action("Index", "Home") }, JsonRequestBehavior.AllowGet);


        }

        public ActionResult Liked(int id)
        {
            var dbliked = _context.Likes.Where(m => m.UserId == id).Select(m => m.AdvertId).ToList();
            var useradv = _context.Adverts.Where(m => m.User.Status == false && dbliked.Contains(m.Id)).ToList();
            return View(useradv);
        }
    }
}