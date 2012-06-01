using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;

namespace Mvc3WebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            ViewBag.aaa = WebConfigurationManager.AppSettings.AllKeys;
            
            return View();
        }

        public ActionResult About()
        {
            
            return View();
        }
    }
}
