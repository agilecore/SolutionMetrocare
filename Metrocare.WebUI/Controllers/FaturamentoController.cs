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
    public class FaturamentoController : Base
    {
        public FaturamentoController()
        {
            LoadMenu();
            ViewBag.Title = "Faturamento";
        }

        public ActionResult Fatura()
        {
            return PartialView();
        }

        public ActionResult Lote()
        {
            return PartialView();
        }

        public ActionResult PagamentoMedico()
        {
            return PartialView();
        }
    }
}
