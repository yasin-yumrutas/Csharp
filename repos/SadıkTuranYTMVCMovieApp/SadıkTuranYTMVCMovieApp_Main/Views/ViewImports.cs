using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SadıkTuranYTMVCMovieApp_Main.Views
{
    public class ViewImports : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
