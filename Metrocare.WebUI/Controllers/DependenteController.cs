using Metrocare.Common;
using Metrocare.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metrocare.WebUI.Controllers
{
    public class DependenteController : Base
    {
        private DependenteBus _dependenteBus { get; set; }

        public DependenteController()
        {
            LoadMenu();
            ViewBag.Title = "Cadastro de Dependentes";
            _dependenteBus = new DependenteBus();
        }

        public ActionResult List(DependenteFilter filter)
        {
            ViewBag.Enable = false;
            ViewBag.filter = ((filter != null) ? filter : new DependenteFilter());

            var result = ((TempData["Result"] == null) ? _dependenteBus.GetByFilter(filter) : TempData["Result"] as List<DependenteDto>);
            return PartialView(result);
        }

        public ActionResult Add()
        {
            ViewBag.Errors = TempData["Errors"] as List<ModelError>;
            var result = ((TempData["Result"] != null) ? TempData["Result"] as DependenteDto : new DependenteDto());
            return PartialView(result);
        }

        public ActionResult Save(DependenteDto model)
        {
            if (ModelState.IsValid)
            {
                _dependenteBus.Add(model);
                return (RedirectToAction("List"));
            }
            else
            {
                TempData["Result"] = model;
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return (RedirectToAction("Add"));
            }
        }

        public ActionResult Find(DependenteFilter filter)
        {
            ViewBag.filter = ((filter != null) ? filter : new DependenteFilter());
            TempData["Result"] = _dependenteBus.GetByFilter(filter);
            return (RedirectToAction("List"));
        }
    }
}
