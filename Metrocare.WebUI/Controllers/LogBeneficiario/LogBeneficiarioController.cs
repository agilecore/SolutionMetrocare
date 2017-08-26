using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class LogBeneficiarioController : Base                                 
    {                                                                               
        internal LogBeneficiario _LogBeneficiario { get; set; }                 
                                                                                    
        public LogBeneficiarioController()                                        
        {                                                                           
            _LogBeneficiario = new LogBeneficiario();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionLogBeneficiario = _LogBeneficiario.GetAll().ToList(); 
            return View(collectionLogBeneficiario);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new LogBeneficiarioDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(LogBeneficiarioDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var LogBeneficiario = new LogBeneficiario();                    
                _LogBeneficiario.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

