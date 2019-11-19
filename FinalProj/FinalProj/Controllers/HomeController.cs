using FinalProj.Data;
using FinalProj.Models;
using FinalProj.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FinalProj.Controllers
{
    public class HomeController : Controller
    {
        FinalProjContext _context;
        public HomeController()
        {
            _context = new FinalProjContext();
        }

        public ActionResult Index()
        {
            forIndex vm;
            if (Session["lguser"] != null)
            {
                User user = Session["lguser"] as User;
                var userlikes = _context.Likes.Where(m => m.UserId == user.Id).Select(m => m.AdvertId).ToList();
                Session["userlike"] = userlikes.Count();
                vm = new forIndex()
                {
                    newHomes = _context.Adverts.Where(m => m.User.Status == false && !userlikes.Contains(m.Id)).OrderByDescending(m => m.CreatedAt).Take(15).ToList(),
                    forVip = _context.Adverts.Where(m => m.User.Status == false && m.IsVip == true && !userlikes.Contains(m.Id)).OrderByDescending(m => m.CreatedAt).ToList(),
                    forRent = _context.Adverts.Where(m => m.User.Status == false && m.RentType.SaleType == "Kiraye" && !userlikes.Contains(m.Id)).OrderByDescending(m => m.IsVip).ThenByDescending(m => m.CreatedAt).ToList(),
                    forSale = _context.Adverts.Where(m => m.User.Status == false && m.RentType.SaleType == "Satiliq" && !userlikes.Contains(m.Id)).OrderByDescending(m => m.IsVip).ThenByDescending(m => m.CreatedAt).ToList(),
                    forPrice = _context.Adverts.Where(m => m.User.Status == false && m.Price <= 500000 && !userlikes.Contains(m.Id)).OrderBy(m => m.Price).ToList()
                };
            }
            else
            {
                vm = new forIndex()
                {
                    newHomes = _context.Adverts.Where(m => m.User.Status == false).OrderByDescending(m => m.CreatedAt).Take(15).ToList(),
                    forVip = _context.Adverts.Where(m => m.User.Status == false && m.IsVip == true).OrderByDescending(m => m.CreatedAt).ToList(),
                    forRent = _context.Adverts.Where(m => m.User.Status == false && m.RentType.SaleType == "Kiraye").OrderByDescending(m => m.IsVip == true).ThenByDescending(m => m.CreatedAt).ToList(),
                    forSale = _context.Adverts.Where(m => m.User.Status == false && m.RentType.SaleType == "Satiliq").OrderByDescending(m => m.IsVip == true).ThenByDescending(m => m.CreatedAt).ToList(),
                    forPrice = _context.Adverts.Where(m => m.User.Status == false && m.Price <= 500000).OrderBy(m => m.Price).ToList()
                };
            }

            return View(vm);
        }

        public async Task<ActionResult> lform(string Name, string Email, string Title, string Content, Message message)
        {
            message.Name = Name;
            message.Email = Email;
            message.Title = Title;
            message.Content = Content;
            message.isRead = false;
            message.CreatedAt = DateTime.Now;

         

            if (!ModelState.IsValid)
            {
                return Json(new { status = "400", messag = "Məlumatlar düzgün daxil edilməyib" }, JsonRequestBehavior.AllowGet);
            }

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return Json(new { status = "200", data = Url.Action("Index", "Home") }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult About()
        {

            var mydata = 56;

            var yb = mydata  > 66 ? "boyukdur" : "Kicikdir";


            return Content(yb);
        }
    }
}