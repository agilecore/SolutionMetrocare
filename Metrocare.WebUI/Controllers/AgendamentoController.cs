using Metrocare.WebUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metrocare.WebUI.Controllers
{
    public class AgendamentoController : Base
    {    
        public AgendamentoController()
        {
            LoadMenu();
            ViewBag.Title = "Agendamento";
        }

        public ActionResult Agenda()
        {
            return PartialView();
        }

        public ActionResult GeraGuia()
        {
            return PartialView();
        }
    }
}
