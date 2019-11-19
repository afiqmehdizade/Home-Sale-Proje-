using FinalProj.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using static FinalProj.FileExtensions.FileExtensions;

namespace FinalProj.Controllers
{
    public class AJAXController : Controller
    {
        FinalProjContext _context;
        public AJAXController()
        {
            _context = new FinalProjContext();
        }

        // GET: AJAX
        public ActionResult _LoadPriceSearch(int? fromprice, int? toprice)
        {
            if (fromprice == null || toprice == null) return HttpNotFound();

            var dbresult = _context.Adverts.Where(m => m.User.Status == false && m.Price >= fromprice && m.Price <= toprice).OrderByDescending(m => m.IsVip == true).ThenBy((m => m.Price)).ToList();

            if (dbresult.Count == 0)
            {
                dbresult = _context.Adverts.Where(m => m.User.Status == false && m.Price <= fromprice && m.Price >= toprice).OrderByDescending(m => m.IsVip == true).ThenBy((m => m.Price)).ToList();
            }

            return PartialView("_PartialPriceSearch", dbresult);
        }


        public ActionResult LoadSearch(int? category, string keysearch)
        {
            if (keysearch == null) return HttpNotFound();

            if (category != null)
            {
                var dbrenttype = _context.RentTypes.Where(m => m.Id == category);
                if (dbrenttype == null) return HttpNotFound();

            }

            var test = _context.Adverts.Where(m => m.User.Status == false).Where(m => m.City.CityName.Contains(keysearch) || m.Address.Contains(keysearch)).OrderByDescending(m => m.IsVip == true).ThenBy((m => m.Price)).ToList();

            if (category != null)
            {
                test = _context.Adverts.Where(m => m.User.Status == false).Where(m => m.City.CityName.Contains(keysearch) || m.Address.Contains(keysearch)).Where(m => m.RentTypeId == category).OrderByDescending(m => m.IsVip == true).ThenBy((m => m.Price)).ToList();
            }

            return PartialView("_PartialLoadSearch", test);



        }


        public ActionResult LoadMore(int userid, int page = 3)
        {
            var user = Session["lguser"] as FinalProj.Models.User;

            if (userid != user.Id) return HttpNotFound();

            var loadinfo = _context.Adverts.OrderByDescending(m => m.CreatedAt).Where(m => m.UserId == userid).Skip(page).Take(3).ToList();


            if (loadinfo != null)
            {
                return PartialView("_LoadMore", loadinfo);

            }

            return Content("");
        }

        public ActionResult LoadSaleMore(int page = 3)
        {
            var loadinfo = _context.Adverts.OrderByDescending(m => m.CreatedAt).Where(m => m.RentTypeId == 1 && m.User.Status == false).Skip(page).Take(3).ToList();

            if (loadinfo != null)
            {
                return PartialView("LoadSaleMore", loadinfo);
            }
            return Content("");
        }
        public ActionResult LoadRentMore(int page = 3)
        {
            var loadinfo = _context.Adverts.OrderByDescending(m => m.CreatedAt).Where(m => m.RentTypeId == 2 && m.User.Status == false).Skip(page).Take(3).ToList();

            if (loadinfo != null)
            {
                return PartialView("LoadRentMore", loadinfo);
            }
            return Content("");
        }

        public async Task<ActionResult> DeleteAdvert(int? deleteid)
        {
            var dbuser = Session["lguser"] as FinalProj.Models.User;
            if (deleteid == null) return Json(new { status = "400" }, JsonRequestBehavior.AllowGet);

            var delitem = _context.Adverts.Find(deleteid);

            if (delitem == null) return Json(new { status = "400" }, JsonRequestBehavior.AllowGet);

            if (delitem.UserId != dbuser.Id) return Json(new { status = "400" }, JsonRequestBehavior.AllowGet);

            DeleteImage("~/Images", delitem.Image);
            _context.Adverts.Remove(delitem);
            await _context.SaveChangesAsync();

            return Json(new { status = "200", data = Url.Action("Index", "User") }, JsonRequestBehavior.AllowGet);
        }
    }
}