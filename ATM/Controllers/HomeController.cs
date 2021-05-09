using ATM.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATM.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var checkingAccountId = db.CheckingAccounts.Where(c => c.ApplicationUserId
           == userId).First().Id;
            
            ViewBag.CheckingAccountId = checkingAccountId;
            return View();
        }

        [ActionName("about-this-atm")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("About");
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "ASPNETMVC5ATM1";
            if(letterCase=="lower")
            {
                return Content(serial.ToLower());
            }

            // return new HttpStatusCodeResult(403);

            //  return Json(new { name = "serial", value = serial }, JsonRequestBehavior.AllowGet);

            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            //TODO : Send message to HQ
            ViewBag.TheMessage = "Having trouble send us message";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            //TODO : Send message to HQ
            ViewBag.TheMessage = "Thanks, We got your message !";

            return View();
        }
    }
}