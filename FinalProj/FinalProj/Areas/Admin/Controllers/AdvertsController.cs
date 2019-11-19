using FinalProj.Data;
using System.Linq;
using System.Web.Mvc;

namespace FinalProj.Areas.Admin.Controllers
{
    [isAdmin]
    public class AdvertsController : Controller
    {
        readonly FinalProjContext _context;
        public AdvertsController()
        {
            _context = new FinalProjContext();
        }
        // GET: Admin/Adverts
        public ActionResult Index()
        {
            return View(_context.Adverts.OrderBy(m => m.CreatedAt).ToList());
        }
        public ActionResult OnlyVip()
        {
            return View(_context.Adverts.Where(m => m.IsVip == true).OrderBy(m => m.CreatedAt).ToList());
        }
        public ActionResult OnlyNew()
        {
            return View(_context.Adverts.Where(m => m.RentTypeId == 1).OrderBy(m => m.CreatedAt).ToList());
        }
        public ActionResult OnlyRent()
        {
            return View(_context.Adverts.Where(m => m.RentTypeId == 2).OrderBy(m => m.CreatedAt).ToList());
        }
        public ActionResult Search()
        {
            return View();
        }
    }
}