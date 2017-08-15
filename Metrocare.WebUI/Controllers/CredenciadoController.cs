using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Metrocare.WebUI.Filters;
using Metrocare.Common;
using Metrocare.Domain;

namespace Metrocare.WebUI.Controllers
{
    public class CredenciadoController : Base
    {
        private CredenciadoBus _credenciadoBus { get; set; }

        public CredenciadoController()
        {
            LoadMenu();
            ViewBag.Title = "Cadastro de Credenciado";
            _credenciadoBus = new CredenciadoBus();
        }

        public ActionResult List(CredenciadoFilter filter)
        {
            ViewBag.Enable = false;
            ViewBag.filter = ((filter != null) ? filter : new CredenciadoFilter());
            
            var result = ((TempData["Result"] == null) ? _credenciadoBus.GetByFilter(filter) : TempData["Result"] as List<CredenciadoDto>);
            return PartialView(result);
        }

        public ActionResult Add()
        {
            ViewBag.Errors = TempData["Errors"] as List<ModelError>;
            var result = ((TempData["Result"] != null) ? TempData["Result"] as CredenciadoDto : new CredenciadoDto());
            return PartialView(result);
        }   

        public ActionResult Save(CredenciadoDto model)
        {
            if (ModelState.IsValid)
            {
                _credenciadoBus.Add(model);
                return (RedirectToAction("List"));
            }
            else
            {
                TempData["Result"] = model;
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return (RedirectToAction("Add"));
            }  
        }

        public ActionResult Find(CredenciadoFilter filter)
        {
            ViewBag.filter = ((filter != null) ? filter : new CredenciadoFilter());
            TempData["Result"] = _credenciadoBus.GetByFilter(filter);
            return (RedirectToAction("List"));
        }

    }
}
