using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Metrocare.WebUI.Filters;

namespace Metrocare.WebUI.Controllers
{
    public class MenuController : Base
    {
        public ActionResult List()
        {
            ViewBag.Enable = false;
            return PartialView();
        }

        public ActionResult Permissoes()
        {
            return PartialView();
        }

        
    }
}
