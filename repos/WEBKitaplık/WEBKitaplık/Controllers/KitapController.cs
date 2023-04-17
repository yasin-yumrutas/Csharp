using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBKitaplık.Models;

namespace WEBKitaplık.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        BookBlogEntities db = new BookBlogEntities();
        public ActionResult Index()
        {
            var kitaplar = db.Kitap.ToList();
            return View(kitaplar);
        }
    }
}