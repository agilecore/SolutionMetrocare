using Metrocare.Common;
using Metrocare.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Metrocare.WebUI.Controllers
{
    public class UsuarioController : Base
    {
        private UsuarioBus _usuarioBus { get; set; }

        public UsuarioController()
        {
            LoadMenu();
            ViewBag.Title = "Cadastro de Usuários";
            _usuarioBus = new UsuarioBus();
        }

        //[HttpGet]
        //public ActionResult List(UsuarioFilter filter)
        //{
        //    ViewBag.Enable = false;
        //    ViewBag.filter = ((filter != null) ? filter : new UsuarioFilter());

        //    var result = ((TempData["Result"] == null) ? _usuarioBus.GetByFilter(filter) : TempData["Result"] as List<UsuarioDto>);
        //    return PartialView(result);
        //}

        [HttpGet]
        public async Task<ActionResult> List(UsuarioFilter filter)
        {
            ViewBag.Enable = false;
            ViewBag.filter = ((filter != null) ? filter : new UsuarioFilter());

            var result = ((TempData["Result"] == null) ? await _usuarioBus.GetByFilterAsync(filter) : TempData["Result"] as List<UsuarioDto>);
            return View(result);
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

        public ActionResult Save(UsuarioDto model)
        {
            if (ModelState.IsValid)
            {
                _usuarioBus.Add(model);
                return (RedirectToAction("List"));
            }
            else
            {
                TempData["Result"] = model;
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return (RedirectToAction("Add"));
            }
        }

        public ActionResult Find(UsuarioFilter filter)
        {
            ViewBag.filter = ((filter != null) ? filter : new UsuarioFilter());
            TempData["Result"] = _usuarioBus.GetByFilter(filter);
            return (RedirectToAction("List"));
        }

    }
}
