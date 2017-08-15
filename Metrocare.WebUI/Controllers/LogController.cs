using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Collections.Generic;
using Metrocare.Common;
using Metrocare.Domain;
using Metrocare.WebUI.Filters;
using System.Threading.Tasks;

namespace Metrocare.WebUI.Controllers
{
    public class LogController : Base
    {
        private LogBus _logBus { get; set; }
        private UsuarioBus _usuarioBus { get; set; }

        public LogController()
        {
            LoadMenu();
            ViewBag.Title = "Logs de Acesso";

            _logBus = new LogBus();
            _usuarioBus = new UsuarioBus();
        }

        //[HttpGet]
        //public ActionResult List(LogFilter filter)
        //{
        //    ViewBag.Enable = false;
        //    ViewBag.filter = ((filter != null) ? filter : new LogFilter());

        //    var result = ((TempData["Result"] == null) ? _logBus.GetByFilter(filter) : TempData["Result"] as List<LogDto>);
        //    return View(result);
        //}

        [HttpGet]
        public async Task<ActionResult> List(LogFilter filter)
        {
            ViewBag.Enable = false;
            ViewBag.filter = ((filter != null) ? filter : new LogFilter());

            var result = ((TempData["Result"] == null) ? await _logBus.GetByFilterAsync(filter) : TempData["Result"] as List<LogDto>);
            return View(result);
        }   

        public ActionResult Buscar(LogFilter filter)
        {
            ViewBag.filter = ((filter != null) ? filter : new LogFilter());
            TempData["Result"] = _logBus.GetByFilter(filter);
            return (RedirectToAction("List"));
        }

        [HttpGet]
        public ActionResult Add(String Id)
        {
            if (!String.IsNullOrEmpty(Id) && Convert.ToInt32(Id) > 0)
            {
                var result = _usuarioBus.GetByFilter(new UsuarioFilter() { id_usuario = Convert.ToInt32(Id) }).FirstOrDefault();
                return View(result);
            }
            else
            {
                ViewBag.Errors = TempData["Errors"] as List<ModelError>;
                var result = ((TempData["Result"] != null) ? TempData["Result"] as UsuarioDto : new UsuarioDto());
                return View(result);
            }
        }
    }
}
