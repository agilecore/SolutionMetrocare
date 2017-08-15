using Metrocare.Common;
using Metrocare.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metrocare.WebUI.Controllers
{
    public class PrestadorController : Base
    {
        private PrestadorBus _prestadorBus { get; set; }

        public PrestadorController()
        {
            LoadMenu();
            ViewBag.Title = "Cadastro de Prestadores";
            _prestadorBus = new PrestadorBus();
        }

        [HttpGet]
        public ActionResult List(PrestadorFilter filter)
        {
            ViewBag.Enable = false;
            ViewBag.filter = ((filter != null) ? filter : new PrestadorFilter());

            var result = ((TempData["Result"] == null) ? _prestadorBus.GetByFilter(filter) : TempData["Result"] as List<PrestadorDto>);
            return PartialView(result);
        }

        [HttpGet]
        public ActionResult Add(String Id)
        {
            if (!String.IsNullOrEmpty(Id) && Convert.ToInt32(Id) > 0)
            {
                var result = _prestadorBus.GetByFilter(new PrestadorFilter() { id_prestador = Convert.ToInt32(Id) }).FirstOrDefault();
                return PartialView(result);
            }
            else
            {
                ViewBag.Errors = TempData["Errors"] as List<ModelError>;
                var result = ((TempData["Result"] != null) ? TempData["Result"] as PrestadorDto : new PrestadorDto());
                return PartialView(result);
            }
        }    

        public ActionResult Save(PrestadorDto model)
        {
            if (ModelState.IsValid)
            {
                _prestadorBus.Add(model);
                return (RedirectToAction("List"));
            }
            else
            {
                TempData["Result"] = model;
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return (RedirectToAction("Add"));
            }  
        }

        public ActionResult Find(PrestadorFilter filter)
        {
            ViewBag.filter = ((filter != null) ? filter : new PrestadorFilter());
            TempData["Result"] = _prestadorBus.GetByFilter(filter);
            return (RedirectToAction("List"));
        }

    }
}
