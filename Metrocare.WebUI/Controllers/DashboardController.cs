using Metrocare.Common;
using Metrocare.WebUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metrocare.WebUI.Controllers
{
    public class DashboardController : Base
    {
        public DashboardController()
        {
            LoadMenu();
            ViewBag.Title = "Dashboard";
        }

        public ActionResult List()
        {
            return View();
        }   
    }
}
