using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProj.Models;
using FinalProj.Data;

namespace FinalProj.Areas.Admin.Controllers
{[isAdmin]
    public class MessagesController : Controller
    {
        readonly FinalProjContext _context;
        public MessagesController()
        {
            _context = new FinalProjContext();
        }
        // GET: Admin/Messages
        public ActionResult Allmessage()
        {
            var messages = _context.Messages.OrderByDescending(m => m.CreatedAt).ToList();
            return View(messages);
        }
        public ActionResult Unread()
        {
            var unread = _context.Messages.Where(m => m.isRead == false).OrderByDescending(m => m.CreatedAt).ToList();
            return View(unread);
        }
        public ActionResult Read()
        {
            var readed = _context.Messages.Where(m => m.isRead == true).OrderByDescending(m => m.CreatedAt).ToList();

            return View(readed);
        }
    }
}