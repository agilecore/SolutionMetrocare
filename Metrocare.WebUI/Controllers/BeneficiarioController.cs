using Metrocare.Common;
using Metrocare.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metrocare.WebUI.Controllers
{
    public class BeneficiarioController : Base
    {
        private BeneficiarioBus _beneficiarioBus { get; set; }

        public BeneficiarioController()
        {
            LoadMenu();
            ViewBag.Title = "Cadastro de Beneficiários";
            _beneficiarioBus = new BeneficiarioBus();
        }

        public ActionResult List(BeneficiarioFilter filter)
        {
            ViewBag.Enable = false;
            ViewBag.filter = ((filter != null) ? filter : new BeneficiarioFilter());

            var result = ((TempData["Result"] == null) ? _beneficiarioBus.GetByFilter(filter) : TempData["Result"] as List<BeneficiarioDto>);
            return PartialView(result);
        }

        public ActionResult Add()
        {
            ViewBag.Errors = TempData["Errors"] as List<ModelError>;
            var result = ((TempData["Result"] != null) ? TempData["Result"] as BeneficiarioDto : new BeneficiarioDto());
            return PartialView(result);
        }      

        public ActionResult Save(BeneficiarioDto model)
        {
            if (ModelState.IsValid)
            {
                _beneficiarioBus.Add(model);
                return (RedirectToAction("List"));
            }
            else
            {
                TempData["Result"] = model;
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return (RedirectToAction("Add"));
            }  
        }

        public ActionResult Find(BeneficiarioFilter filter)
        {
            ViewBag.filter = ((filter != null) ? filter : new BeneficiarioFilter());
            TempData["Result"] = _beneficiarioBus.GetByFilter(filter);
            return (RedirectToAction("List"));
        }
    }
}
