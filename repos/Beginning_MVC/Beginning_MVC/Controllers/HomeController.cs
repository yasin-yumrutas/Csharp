using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beginning_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Sayfamızın Açılımı "+"'Model_View_Controller'";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kişinin bilgileri";

            return View();
        }
        public ActionResult Bilgi()
        {
            return View();
        }   
        public ActionResult MyProfil()
        {
            return View();
        }
    }
}