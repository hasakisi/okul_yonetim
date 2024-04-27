using okul_yonetim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace okul_yonetim.Controllers
{
    public class HomeController : Controller
    {
        Database1Entities1 db = new Database1Entities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Yonetici log)
        {
            var user = db.Yonetici.FirstOrDefault(x => x.YoneticiAd == log.YoneticiAd && x.YoneticiSoyad == log.YoneticiSoyad);

            if (user != null)
            {
                Session["AdminName"] = user.YoneticiAd;
                Session["AdminName"] = user.YoneticiAd;

                return View("Dashboard");
            }   

            else
            {
                return View();
            }
        }   
        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Dashboard()
        {
            return View();

        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

           
            return View();
        }

    
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}