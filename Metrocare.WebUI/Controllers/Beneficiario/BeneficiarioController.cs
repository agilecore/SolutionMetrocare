using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class BeneficiarioController : Base                                 
    {                                                                               
        internal Beneficiario _Beneficiario { get; set; }                 
                                                                                    
        public BeneficiarioController()                                        
        {                                                                           
            _Beneficiario = new Beneficiario();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionBeneficiario = _Beneficiario.GetAll().ToList(); 
            return View(collectionBeneficiario);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new BeneficiarioDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(BeneficiarioDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var Beneficiario = new Beneficiario();                    
                _Beneficiario.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

