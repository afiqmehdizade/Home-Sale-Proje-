using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProj.Models;
using FinalProj.ViewModels;
using FinalProj.Data;
using static FinalProj.FileExtensions.FileExtensions;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FinalProj.Controllers
{
    [Authorization]
    public class AdvertController : Controller
    {
        FinalProjContext _context;
        public AdvertController()
        {
            _context = new FinalProjContext();
        }

        // GET: Advert
        [AllowAnonymous]
        public ActionResult Detail(int? id)
        {
            if (id == null) return HttpNotFound();

            var dbadvert = _context.Adverts.Find(id);

            if (dbadvert == null) return HttpNotFound();

            forDetail vm = new forDetail()
            {
                adverts = _context.Adverts.Where(m => m.User.Status == false && m.CityId == dbadvert.CityId && m.Id != dbadvert.Id).OrderByDescending(m => m.IsVip == true).ThenBy(m => m.CreatedAt).ToList(),
                dbadvert = dbadvert
            };


            return View(vm);
        }


        public ActionResult Create()
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.RentType = _context.RentTypes.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult>Create([Bind(Include = "Price,RoomCount,BedRoom,BathRoom,RoomArea,CreatedAt,Description,IsVip,IsNew,Photo,RentTypeId,UserId,CityId,Address")]Advert advert)
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.RentType = _context.RentTypes.ToList();
            var CurrentUser = Session["lguser"] as FinalProj.Models.User;
            if (!ModelState.IsValid) return View(advert);

            if (advert.Photo == null)
            {
                ModelState.AddModelError("Photo", "Şəkli Daxil Edin!");
                return View(advert);
            }

            if (!advert.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Şəkli Daxil Edin!");
                return View(advert);
            }

            advert.Image = advert.Photo.SaveImage("homes");
            advert.CreatedAt = DateTime.Now;
            advert.UserId = CurrentUser.Id;
            _context.Adverts.Add(advert);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index","User");
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.RentType = _context.RentTypes.ToList();

            if (id == null) return HttpNotFound();

            var editadv = _context.Adverts.Find(id);
            var dbuser = Session["lguser"] as User;

            if (editadv == null) return HttpNotFound();

            if (editadv.UserId != dbuser.Id) return HttpNotFound();

            return View(editadv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserId,Image,CreatedAt,Price,RoomCount,BedRoom,BathRoom,RoomArea,CreatedAt,Description,IsVip,IsNew,Photo,RentTypeId,UserId,CityId,Address")]Advert advert)
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.RentType = _context.RentTypes.ToList();
            
            if (!ModelState.IsValid) return View(advert);

            if (advert.Photo != null)
            {
               if(!advert.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Şəkli Daxil Edin!");
                    return View(advert);
                }
                DeleteImage("~/Images", advert.Image);
                advert.Image=advert.Photo.SaveImage("homes");
            }

            _context.Entry(advert).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            

            return RedirectToAction("Index","User");
        }
        [AllowAnonymous]
        public ActionResult Sale()
        {
            ViewBag.TotalSaleCount = _context.Adverts.Where(m => m.RentTypeId == 1 && m.User.Status == false).Count();
            var dbsaled = _context.Adverts.Where(m => m.RentTypeId == 1 && m.User.Status==false).OrderByDescending(m => m.CreatedAt).Take(6).ToList();
            return View(dbsaled);
        }
        [AllowAnonymous]
        public ActionResult Rent()
        {
            ViewBag.TotalRentCount = _context.Adverts.Where(m => m.RentTypeId == 2 && m.User.Status == false).Count();
            var dbrented = _context.Adverts.Where(m => m.RentTypeId == 2 && m.User.Status == false).OrderByDescending(m => m.CreatedAt).Take(6).ToList();
            return View(dbrented);
        }
    }
}