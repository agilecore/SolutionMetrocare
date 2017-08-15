using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Collections.Generic;
using Metrocare.Common;
using Metrocare.Domain;
using Metrocare.WebUI.Filters;

namespace Metrocare.WebUI.Controllers
{
    public class PlanoController : Base
    {
        public PlanoController()
        {
            LoadMenu();
            ViewBag.Title = "Planos";
        }      

        public ActionResult List()
        {
            ViewBag.Enable = false;
            return PartialView();
        }


        public ActionResult Tabela()
        {
            return PartialView();
        }


        public ActionResult Tuss()
        {
            return PartialView();
        }
    }
}
